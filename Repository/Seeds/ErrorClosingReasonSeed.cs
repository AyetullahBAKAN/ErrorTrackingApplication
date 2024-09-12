//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Seeds
//{
//    internal class ErrorClosingReasonSeed : IEntityTypeConfiguration<ErrorClosingReason>
//    {
//        public void Configure(EntityTypeBuilder<ErrorClosingReason> builder)
//        {
//            builder.HasData(new ErrorClosingReason
//            {
//                Id = Guid.NewGuid(),
//                Reason = "Hatanın Sebebi",
//                CreateDate = DateTime.Now,
//                IsActive = true,
//            });
//        }
//    }
//}
