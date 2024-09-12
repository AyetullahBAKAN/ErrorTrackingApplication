using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(x=>x.UnitName).IsRequired().HasMaxLength(100);

         //   builder.HasMany(x => x.ErrorCards).WithOne(x => x.Unit).HasForeignKey(x => x.UnitId);
        }
    }
}

