using BeycelikTransport.DataAccess.Extensions;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cost> Cost { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ErrorCard> ErrorCard { get; set; }
        public DbSet<ErrorClass> ErrorClass { get; set; }
        public DbSet<ErrorClosingReason> ErrorClosingReason { get; set; }
        public DbSet<ErrorDefine> ErrorDefine { get; set; }
        public DbSet<ErrorDetailGroup> ErrorDetailGroup { get; set; }
        public DbSet<ErrorDetailSub> ErrorDetailSub { get; set; }
        public DbSet<ErrorDetectionLocation> ErrorDetectionLocation { get; set; }
        public DbSet<ErrorMainSub> ErrorMainSub { get; set; }
        public DbSet<ErrorMainTitle> ErrorMainTitle { get; set; }
        public DbSet<ErrorSubGroup> ErrorSubGroup { get; set; }
        public DbSet<ErrorType> ErrorType { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaErrorDefine> MediaErrorDefine { get; set; }
        public DbSet<MediaSolutionAndStandardizition> MediaSolutionAndStandardizition { get; set; }
        public DbSet<MoneyType> MoneyType { get; set; }
        public DbSet<MontageLetter> MontageLetter { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Part> Part { get; set; }
        public DbSet<Pattern> Pattern { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RootAnalysis> RootAnalysis { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<SolutionAndStandardizition> SolutionAndStandardizition { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.Id = Guid.NewGuid();
                                entityReference.CreateDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.Id = Guid.NewGuid();
                                entityReference.CreateDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreateDate).IsModified = false;
                                entityReference.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);

            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            modelBuilder.AddRemovePluralizeConvention();

            modelBuilder.AddRemoveOneToManyCascadeConvention();

            modelBuilder.ApplyConventions();

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
