using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class PatternConfiguration : IEntityTypeConfiguration<Pattern>
    {
        public void Configure(EntityTypeBuilder<Pattern> builder)
        {
            builder.HasOne(x => x.Customer).WithMany(x => x.Patterns).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Project).WithMany(x => x.Patterns).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MontageLetter).WithMany(x => x.Patterns).HasForeignKey(x => x.MontageLetterId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Part).WithMany(x => x.Patterns).HasForeignKey(x => x.PartId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Operation).WithMany(x => x.Patterns).HasForeignKey(x => x.OperationId).OnDelete(DeleteBehavior.NoAction);

            
            builder.HasMany(x => x.ErrorCards).WithOne(x => x.Pattern).HasForeignKey(x => x.PatternId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
