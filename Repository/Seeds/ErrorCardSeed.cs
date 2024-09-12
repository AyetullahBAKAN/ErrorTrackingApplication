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
//    internal class ErrorCardSeed : IEntityTypeConfiguration<ErrorCard>
//    {
//        public void Configure(EntityTypeBuilder<ErrorCard> builder)
//        {
//            builder.HasData(new ErrorCard
//            {
//                Id=Guid.NewGuid(),
//                PageNumber=1,
//                FormNumber="1A",
//                RevNumber=1,
//                UserId=Guid.Parse("E6BA61DB-6206-4AA9-EA0D-08DC15A26E0A"),//ibrhmygn7887@gmail.com
//                DateStart=DateTime.Now,
//                DateFinish=DateTime.Now,
//                PatternId=Guid.Parse("B0E2C25D-A4AF-4E0D-BF60-4F5AAAD9C2E9"),
//                ErrorDefineId=Guid.Parse("7A21F2D5-D9AC-47BF-8653-36474AB1CBB6"),
//                ErrorClassId=Guid.Parse("5824119E-9AE7-4786-BA03-8B8786CF88FE"),
//                RootAnalysisId=Guid.Parse("52001537-8DAF-450E-B9C9-FE5793BA3ED2"),
//                SolutionAndStandardizitionId=Guid.Parse("D6B7107A-C126-44F3-A265-6C3395C1A1B0"),
//                CostId=Guid.Parse("0C3ABA21-2E4A-4C5A-8BCD-2BAEF73A8306"),
//                ErrorDetectionLocationId=Guid.Parse("DA34C50E-0039-4BB9-A89B-24015E457182"),//process
//                UnitId=Guid.Parse("CAD2B84F-B68E-4C38-94BE-BEDD9FC9D254"),//process
//                StateId=Guid.Parse("5E45933B-210D-4FD8-AEA3-355BB9B905BC"), // 
//                CreateDate=DateTime.Now,
//                IsActive=true
//            });
//        }
//    }
//}
