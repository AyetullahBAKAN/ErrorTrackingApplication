using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorMainTitleConfiguraiton : IEntityTypeConfiguration<ErrorMainTitle>
    {
        public void Configure(EntityTypeBuilder<ErrorMainTitle> builder)
        {
            builder.Property(x => x.ErrorMainTitleName).IsRequired().HasMaxLength(200);

          //  builder.HasMany(x => x.ErrorClasses).WithOne(x => x.ErrorMainTitle).HasForeignKey(x => x.ErrorMainTitleId);
        }
    }
}
