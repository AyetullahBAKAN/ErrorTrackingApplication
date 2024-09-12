using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorMainSubConfiguration : IEntityTypeConfiguration<ErrorMainSub>
    {
        public void Configure(EntityTypeBuilder<ErrorMainSub> builder)
            
        {
            builder.HasKey(x => new { x.ErrorMainTitleId, x.ErrorSubGroupId }); 

            builder.HasOne(x => x.ErrorMainTitle).WithMany(x => x.ErrorMainSubs).HasForeignKey(x => x.ErrorMainTitleId);
            builder.HasOne(x => x.ErrorSubGroup).WithMany(x => x.ErrorMainSubs).HasForeignKey(x => x.ErrorSubGroupId);
        }
    }
}
