using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class ErrorClosingReasonConfiguration : IEntityTypeConfiguration<ErrorClosingReason>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ErrorClosingReason> builder)
        {
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(400);

        //    builder.HasMany(x => x.SolutionAndStandardizitions).WithOne(x => x.ErrorClosingReason).HasForeignKey(x => x.ErrorClosingReasonId);

        }
    }
}
