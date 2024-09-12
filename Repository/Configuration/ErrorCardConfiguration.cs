using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorCardConfiguration : IEntityTypeConfiguration<ErrorCard>
    {
        public void Configure(EntityTypeBuilder<ErrorCard> builder)
        {
            builder.Property(x => x.PageNumber).IsRequired();
            builder.Property(x=>x.FormNumber).IsRequired().HasMaxLength(255);
            builder.Property(x => x.RevNumber).IsRequired();
            builder.Property(x=>x.DateStart).IsRequired();
            builder.Property(x => x.DateFinish).IsRequired();

            builder.HasOne(x=>x.User).WithMany(x=>x.ErrorCards).HasForeignKey(x=>x.UserId);
            builder.HasOne(x => x.Pattern).WithMany(x => x.ErrorCards).HasForeignKey(x => x.PatternId);
            builder.HasOne(x => x.ErrorDefine).WithMany(x => x.ErrorCards).HasForeignKey(x => x.ErrorDefineId);
            builder.HasOne(x => x.ErrorClass).WithMany(x => x.ErrorCards).HasForeignKey(x => x.ErrorClassId);
            builder.HasOne(x => x.ErrorDetectionLocation).WithMany(x => x.ErrorCards).HasForeignKey(x => x.ErrorDetectionLocationId);
            builder.HasOne(x => x.SolutionAndStandardizition).WithMany(x => x.ErrorCards).HasForeignKey(x => x.SolutionAndStandardizitionId);
            builder.HasOne(x => x.RootAnalysis).WithMany(x => x.ErrorCards).HasForeignKey(x => x.RootAnalysisId);
            builder.HasOne(x => x.Unit).WithMany(x => x.ErrorCards).HasForeignKey(x => x.UnitId);
            builder.HasOne(x => x.States).WithMany(x => x.ErrorCards).HasForeignKey(x => x.StateId);
            builder.HasOne(x => x.Cost).WithMany(x => x.ErrorCards).HasForeignKey(x => x.CostId);


        }
    }
}
