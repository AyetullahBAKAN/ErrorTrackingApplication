//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class SolutionAndStandardizitionSeed : IEntityTypeConfiguration<SolutionAndStandardizition>
//    {
//        public void Configure(EntityTypeBuilder<SolutionAndStandardizition> builder)
//        {
//            builder.HasData(
//                new SolutionAndStandardizition
//                {
//                    Id = Guid.NewGuid(),
//                    ErrorClosingReasonId = Guid.Parse("b5ea940d-7e03-4150-ac79-115d81d70016"),
//                    SolutionShort = "Kısa Çözüm",
//                    SolutionPerma = "Kalıcı Çözüm",
//                    SolutionDetail = "Çözümün Detayı",
//                    HowErrorClose = "Hata Nasıl Kapatıldı",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                });
//        }
//    }
//}
