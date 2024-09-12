using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorClassConfiguration : IEntityTypeConfiguration<ErrorClass>
    {
        public void Configure(EntityTypeBuilder<ErrorClass> builder)
        {
            builder.Property(x => x.ShortDetail).IsRequired().HasMaxLength(200);

         //   builder.HasMany(x => x.ErrorCards).WithOne(x => x.ErrorClass).HasForeignKey(x => x.ErrorClassId);
            builder.HasOne(x => x.ErrorMainTitle).WithMany(x => x.ErrorClasses).HasForeignKey(x => x.ErrorMainTitleId);
            builder.HasOne(x => x.ErrorSubGroup).WithMany(x => x.ErrorClasses).HasForeignKey(x => x.ErrorSubGroupId);

        }
    }
}
