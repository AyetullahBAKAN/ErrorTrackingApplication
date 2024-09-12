using Core.IRepository;
using Core.IService;
using Core.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repository;
using Repository.UnitOfWorks;
using Service.Mapping;
using Service.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<CustomerRepositoy>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<MontageLetterRepository>();
builder.Services.AddScoped<MontageLetterService>();
builder.Services.AddScoped<OperationRepository>();
builder.Services.AddScoped<OperationService>();
builder.Services.AddScoped<PartRepository>();
builder.Services.AddScoped<PartService>();
builder.Services.AddScoped<PatternRepository>();
builder.Services.AddScoped<PatternService>();
builder.Services.AddScoped<RootAnalysisRepository>();
builder.Services.AddScoped<RootAnalysisService>();
builder.Services.AddScoped<UnitRepository>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<StateRepository>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<FieldRepository>();
builder.Services.AddScoped<FieldService>();
builder.Services.AddScoped<ErrorDetectionLocationService>();
builder.Services.AddScoped<ErrorDetectionLocationRepository>();
builder.Services.AddScoped<CostService>();
builder.Services.AddScoped<CostRepository>();
builder.Services.AddScoped<ErrorDefineRepository>();
builder.Services.AddScoped<ErrorDefineService>();
builder.Services.AddScoped<SolutionAndStandardizitonService>();
builder.Services.AddScoped<SolutionAndStandardizitionRepository>();
builder.Services.AddScoped<ErrorClosingReasonRepository>();
builder.Services.AddScoped<ErrorClosingReasonService>();
builder.Services.AddScoped<ErrorClassService>();
builder.Services.AddScoped<ErrorClassRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<ErrorMainTitleRepository>();
builder.Services.AddScoped<ErrorMainTitleService>();
builder.Services.AddScoped<ErrorSubGroupRepository>();
builder.Services.AddScoped<ErrorSubGroupService>();
builder.Services.AddScoped<ErrorSubGroupRepository>();
builder.Services.AddScoped<ErrorDetailGroupService>();
builder.Services.AddScoped<ErrorTypeRepository>();
builder.Services.AddScoped<ErrorTypeService>();
builder.Services.AddScoped<ErrorCardRepository>();
builder.Services.AddScoped<ErrorCardService>();
builder.Services.AddScoped<MediaRepository>();
builder.Services.AddScoped<MediaService>();




// builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// sonsuz döngüye girdigi icin çözüm önerisi fakat basarisiz .!!



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
