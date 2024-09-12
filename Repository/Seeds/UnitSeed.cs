//using Core.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Repository.Seeds
//{
//    internal class UnitSeed : IEntityTypeConfiguration<Unit>
//    {
//        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Unit> builder)
//        {
//            builder.HasData(
//                new Unit
//                {
//                    Id = Guid.NewGuid(),
//                    UnitName = "PROSES",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                },
//                new Unit
//                {
//                    Id = Guid.NewGuid(),
//                    UnitName = "BİLGİ İŞLEM",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                },
//                new Unit
//                {
//                    Id = Guid.NewGuid(),
//                    UnitName = "CNC",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                });
//        }
//    }
//}
