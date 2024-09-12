using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    internal class SolutionAndStardardizitionConfiguraiton : IEntityTypeConfiguration<SolutionAndStandardizition>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SolutionAndStandardizition> builder)
        {
            builder.Property(x=>x.SolutionShort).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SolutionPerma).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SolutionDetail).IsRequired().HasMaxLength(250);
            builder.Property(x => x.HowErrorClose).IsRequired().HasMaxLength(250);

         //   builder.HasMany(x => x.ErrorCards).WithOne(x => x.SolutionAndStandardizition).HasForeignKey(x => x.SolutionAndStandardizitionId);
            builder.HasOne(x => x.ErrorClosingReason).WithMany(x => x.SolutionAndStandardizitions).HasForeignKey(x => x.ErrorClosingReasonId);

        }
    }
}
