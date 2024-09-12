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
    internal class MontageLetterConfigurations : IEntityTypeConfiguration<MontageLetter>
    {
        public void Configure(EntityTypeBuilder<MontageLetter> builder)
        {
            builder.Property(x=>x.MontageNumber).IsRequired().HasMaxLength(50);
           // builder.HasMany(x => x.Patterns).WithOne(x => x.MontageLetter).HasForeignKey(x => x.MontageLetterId);
        }
    }
}
