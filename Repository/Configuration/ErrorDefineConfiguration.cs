using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorDefineConfiguration : IEntityTypeConfiguration<ErrorDefine>
    {
        public void Configure(EntityTypeBuilder<ErrorDefine> builder)
        {
            builder.Property(x => x.ErrorExplain).IsRequired().HasMaxLength(250);

       //     builder.HasMany(x => x.ErrorCards).WithOne(x => x.ErrorDefine).HasForeignKey(x => x.ErrorDefineId);
        //    builder.HasMany(x => x.MediaErrorDefines).WithOne(x => x.ErrorDefine).HasForeignKey(x => x.ErrorDefineId);
        }
    }
}
