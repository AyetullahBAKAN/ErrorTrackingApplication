using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(200);

          //  builder.HasOne(x => x.Customer).WithMany(x => x.Projects).HasForeignKey(x => x.CustomerId);
        }
    }
}
