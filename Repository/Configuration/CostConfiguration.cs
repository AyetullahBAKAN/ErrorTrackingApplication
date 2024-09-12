using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class CostConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(16,4)");

          
           

            builder.HasOne(x => x.Field).WithMany(x => x.Costs).HasForeignKey(x => x.FieldId);
            builder.HasOne(x => x.MoneyType).WithMany(x => x.Costs).HasForeignKey(x => x.MoneyTypeId);
      //   builder.HasMany(x => x.ErrorCards).WithOne(x => x.Cost).HasForeignKey(x => x.CostId);

        }
    }
}
