using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorSubGroupConfiguration : IEntityTypeConfiguration<ErrorSubGroup>
    {
        public void Configure(EntityTypeBuilder<ErrorSubGroup> builder)
        {
            builder.Property(x => x.ErrorSubGroupName).IsRequired().HasMaxLength(100);

         //   builder.HasMany(x => x.ErrorClasses).WithOne(x => x.ErrorSubGroup).HasForeignKey(x => x.ErrorSubGroupId);
        }
    }
}
