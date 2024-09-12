using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class MoneyTypeConfiguration : IEntityTypeConfiguration<MoneyType>
    {
        public void Configure(EntityTypeBuilder<MoneyType> builder)
        {
            builder.Property(x => x.TypeOfMoney).IsRequired().HasMaxLength(50);

            // builder.HasMany(x => x.Costs).WithOne(x => x.MoneyType).HasForeignKey(x => x.MoneyTypeId);

        }
    }
}
