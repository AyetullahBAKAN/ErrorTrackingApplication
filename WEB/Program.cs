using Core.IRepository;
using Core.IService;
using Core.IUnitOfWorks;
using Core.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repository;
using Repository.UnitOfWorks;
using Service.Mapping;
using Service.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Razor View Engine Options
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // Untested. You could remove this if you don't care about areas.
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Areas/{2}/Pages/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Pages/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/Layouts/Main/{0}" + RazorViewEngine.ViewExtension);
    options.AreaViewLocationFormats.Add("/Views/Shared/Layouts/Login/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<ErrorCardRepository>();
builder.Services.AddScoped<ErrorCardService>();
builder.Services.AddScoped<ErrorDetailGroupService>();
builder.Services.AddScoped<ErrorSubGroupService>();
builder.Services.AddScoped<ErrorMainTitleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<ErrorTypeService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<MontageLetterService>();
builder.Services.AddScoped<PartService>();
builder.Services.AddScoped<OperationService>();
builder.Services.AddScoped<PatternService>();
builder.Services.AddScoped<RootAnalysisService>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<ErrorDetectionLocationService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<ErrorCardService>();
builder.Services.AddScoped<ErrorClassService>();
builder.Services.AddScoped<FieldService>();
builder.Services.AddScoped<MoneyTypeService>();
builder.Services.AddScoped<CostService>();
builder.Services.AddScoped<ErrorDefineService>();
builder.Services.AddScoped<SolutionAndStandardizitonService>();
builder.Services.AddScoped<ErrorClosingReasonService>();
builder.Services.AddScoped<MediaService>();

CookieBuilder cookieBuilder = new CookieBuilder()
{
    Name = "KT",
    HttpOnly = false,
    SameSite = SameSiteMode.Lax,
    SecurePolicy = CookieSecurePolicy.SameAsRequest
};

// Configure Application Cookie
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = new PathString("/Identity/Account/Login");
    opts.LogoutPath = new PathString("/Identity/Account/Logout");
    opts.Cookie = cookieBuilder;
    opts.SlidingExpiration = true;
    opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);
    opts.AccessDeniedPath = new PathString("/NotAuthorize");
});

// AddSession
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(180);
    options.Cookie.IsEssential = true;
});

// FormOptions
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = 5000;
    x.MultipartBodyLengthLimit = 10L * 1024L * 1024L * 1024L;
    x.MultipartHeadersLengthLimit = 737280000;
});

// SecurityStampValidatorOptions
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

// IISServerOptions
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 10L * 1024L * 1024L * 1024L;
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<Role>()
    .AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var roles = new[] { "Admin", "Manager", "Member" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new Role()
            {
                Name = role,
                NormalizedName = role.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString("N")
            });
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();


    string email = "admin3@gmail.com";
    string password = "Iy_114147";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.Name = "ismet";
        user.SurName = "akpýnar";
        user.UserName = email;
        user.Email = email;


        var userResult = await userManager.CreateAsync(user, password);
        if (!userResult.Succeeded)
            throw new Exception(string.Format("Kullanýcý oluþturulurken hata oluþmuþtur. Detay: {0}", userResult.Errors));

        var role = await roleManager.Roles?.FirstOrDefaultAsync(c => c.Name == "Admin");
        if (role == null)
            throw new Exception(string.Format("Böyle bir rol bulunamadý. Detay: Admin"));

        var userAddRoleResult = await userManager.AddToRoleAsync(user, role.NormalizedName);
        if (!userAddRoleResult.Succeeded)
            throw new Exception(string.Format("Kullanýcýya rol atamasý yapýlýrken hata oluþmuþtur. Detay: {0}", userAddRoleResult.Errors));

    }
}

app.MapRazorPages();

// Areas Map Controller Route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// This middleware is used to add Razor Pages endpoints to the request pipeline.    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
