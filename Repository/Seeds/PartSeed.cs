//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class PartSeed : IEntityTypeConfiguration<Part>
//    {
//        public void Configure(EntityTypeBuilder<Part> builder)
//        {
//            builder.HasData(
//                new Part
//                {
//                    Id = Guid.NewGuid(),
//                    PartNo = "0203900021_22_", //togg
//                    CreateDate = DateTime.Now,
//                    IsActive = true
//                });
//        }
//    }
//}
