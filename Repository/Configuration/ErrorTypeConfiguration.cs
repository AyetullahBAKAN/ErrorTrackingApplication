using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class ErrorTypeConfiguration : IEntityTypeConfiguration<ErrorType>
    {
        public void Configure(EntityTypeBuilder<ErrorType> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.ErrorTypes).HasForeignKey(x => x.UserId);
            builder.HasOne(x=>x.ErrorDetailGroup).WithMany(x => x.ErrorTypes).HasForeignKey(x => x.ErrorDetailGroupId);
            builder.HasOne(x=>x.ErrorMainTitle).WithMany(x=>x.ErrorTypes).HasForeignKey(x => x.ErrorMainTitleId);
            builder.HasOne(x => x.ErrorSubGroup).WithMany(x => x.ErrorTypes).HasForeignKey(x => x.ErrorSubGroupId);
        }
    }
}
