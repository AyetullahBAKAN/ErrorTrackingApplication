//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class FieldSeed : IEntityTypeConfiguration<Field>
//    {
//        public void Configure(EntityTypeBuilder<Field> builder)
//        {
//            builder.HasData(
//                new Field
//                {
//                    Id = Guid.NewGuid(),
//                    FieldName = "CAM",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                },
//                new Field
//                {
//                    Id = Guid.NewGuid(),
//                    FieldName = "CNC",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                },
//                new Field
//                {
//                    Id = Guid.NewGuid(),
//                    FieldName = "KALİTE",
//                    CreateDate = DateTime.Now,
//                    IsActive = true,
//                });
//        }
//    }
//}
