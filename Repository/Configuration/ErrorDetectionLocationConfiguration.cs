using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorDetectionLocationConfiguration : IEntityTypeConfiguration<ErrorDetectionLocation>
    {
        public void Configure(EntityTypeBuilder<ErrorDetectionLocation> builder)
        {
            builder.Property(x=>x.ErrorLocation).IsRequired().HasMaxLength(200);

        //    builder.HasMany(x => x.ErrorCards).WithOne(x => x.ErrorDetectionLocation).HasForeignKey(x => x.ErrorDetectionLocationId);
        }
    }
}
