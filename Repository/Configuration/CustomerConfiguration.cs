using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);

            //builder.HasMany(x => x.Projects).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
            //builder.HasMany(x => x.Patterns).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

        }
    }
}
