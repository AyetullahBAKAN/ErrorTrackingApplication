using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class MediaErrorDefineConfiguration : IEntityTypeConfiguration<MediaErrorDefine>
    {
        public void Configure(EntityTypeBuilder<MediaErrorDefine> builder)
        {
            builder.HasKey(x => new { x.ErrorDefineId, x.MediaId });

            builder.HasOne(x => x.ErrorDefine).WithMany(x => x.MediaErrorDefines).HasForeignKey(x => x.ErrorDefineId);
            builder.HasOne(x => x.Media).WithMany(x => x.MediaErrorDefines).HasForeignKey(x => x.MediaId);
        }
    }
}
