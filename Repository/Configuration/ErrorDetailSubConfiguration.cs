using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorDetailSubConfiguration : IEntityTypeConfiguration<ErrorDetailSub>
    {
        public void Configure(EntityTypeBuilder<ErrorDetailSub> builder)
        {

            builder.HasKey(x=> new {x.ErrorDetailGroupId, x.ErrorSubGroupId});

            builder.HasOne(x => x.ErrorDetailGroup).WithMany(x => x.ErrorDetailSubs).HasForeignKey(x => x.ErrorDetailGroupId);
            builder.HasOne(x => x.ErrorSubGroup).WithMany(x => x.ErrorDetailSubs).HasForeignKey(x => x.ErrorSubGroupId);

        }
    }
}
