//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class PatternSeed : IEntityTypeConfiguration<Pattern>
//    {
//        public void Configure(EntityTypeBuilder<Pattern> builder)
//        {
//            builder.HasData(
//                new Pattern
//                {
//                    Id = Guid.NewGuid(),
//                    MontageLetterId = Guid.Parse("873f5156-1b3d-4201-b83c-dd5e9a172f71"), //22AFN
//                    ProjectId = Guid.Parse("b7954b9b-913b-46f9-b4cb-250ce9453343"), //TOGG_C_SUV
//                    CustomerId = Guid.Parse("c77f95f6-d8cc-406b-8598-d32dc75969e8"), //togg
//                    PartId = Guid.Parse("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"),// 0203900021_22_
//                    OperationId = Guid.Parse("eb1d520d-da4e-4714-9a42-43cd0919d41c"),//OP10_ACINIM
//                    CreateDate = DateTime.Now,
//                    IsActive = true
//                });
//        }
//    }
//}
