using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(200);

          //  builder.HasMany(x => x.MediaErrorDefines).WithOne(x => x.Media).HasForeignKey(x => x.MediaId);
        }
    }
}
