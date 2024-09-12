using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class RootAnalysisConfiguration : IEntityTypeConfiguration<RootAnalysis>
    {
        public void Configure(EntityTypeBuilder<RootAnalysis> builder)
        {
            builder.Property(x => x.WhyOne).IsRequired().HasMaxLength(250);
            builder.Property(x => x.WhyTwo).IsRequired().HasMaxLength(250);
            builder.Property(x => x.WhyThree).IsRequired().HasMaxLength(250);
            builder.Property(x => x.WhyRoot).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Result).IsRequired().HasMaxLength(250);

           // builder.HasMany(x => x.ErrorCards).WithOne(x => x.RootAnalysis).HasForeignKey(x => x.RootAnalysisId);
        }
    }
}
