using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(x => x.StateName).IsRequired().HasMaxLength(100);


            //   builder.HasMany(x => x.ErrorCards).WithOne(x => x.States).HasForeignKey(x => x.StateId);

        }
    }
}
