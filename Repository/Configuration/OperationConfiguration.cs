using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.Property(x=>x.OperationNo).IsRequired().HasMaxLength(50);
         //   builder.HasMany(x=>x.Patterns).WithOne(x=>x.Operation).HasForeignKey(x=>x.OperationId);

        }
    }
}
