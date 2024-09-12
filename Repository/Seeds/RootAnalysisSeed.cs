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
//    internal class RootAnalysisSeed : IEntityTypeConfiguration<RootAnalysis>
//    {
//        public void Configure(EntityTypeBuilder<RootAnalysis> builder)
//        {
//            builder.HasData(
//                new RootAnalysis
//                {
//                    Id = Guid.NewGuid(),
//                    WhyOne = "SebepBir",
//                    WhyTwo = "Sebepİki",
//                    WhyThree = "SebepUç",
//                    WhyRoot = "HataninKökü",
//                    Result = "Sonuç",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                });
//        }
//    }
//}
