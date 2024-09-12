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
    internal class ErrorDetailGroupConfiguration : IEntityTypeConfiguration<ErrorDetailGroup>
    {
        public void Configure(EntityTypeBuilder<ErrorDetailGroup> builder)
        {
           builder.Property(x=>x.ErrorDetailGroupName).IsRequired().HasMaxLength(100);

        //    builder.HasMany(x => x.ErrorDetailSubs).WithOne(x => x.ErrorDetailGroup).HasForeignKey(x => x.ErrorDetailGroupId);
          //  builder.HasMany(x => x.ErrorTypes).WithOne(x => x.ErrorDetailGroup).HasForeignKey(x => x.ErrorDetailGroupId);
        }
    }
}
