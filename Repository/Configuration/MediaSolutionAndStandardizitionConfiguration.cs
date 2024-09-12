using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class MediaSolutionAndStandardizitionConfiguration : IEntityTypeConfiguration<MediaSolutionAndStandardizition>
    {
        public void Configure(EntityTypeBuilder<MediaSolutionAndStandardizition> builder)
        {
            builder.HasKey(x => new {x.SolutionAndStandardizitionId,x.MediaId});

            builder.HasOne(x => x.Media).WithMany(x => x.MediaSolutionAndStandardizitions).HasForeignKey(x=>x.MediaId);
            builder.HasOne(x => x.SolutionAndStandardizition).WithMany(x => x.MediaSolutionAndStandardizitions).HasForeignKey(x => x.SolutionAndStandardizitionId);
        }
    }
}
