using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    internal class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Part> builder)
        {
            builder.Property(x => x.PartNo).IsRequired().HasMaxLength(50);
          //  builder.HasMany(x => x.Patterns).WithOne(x => x.Part).HasForeignKey(x => x.PartId);
        }
    }
}
