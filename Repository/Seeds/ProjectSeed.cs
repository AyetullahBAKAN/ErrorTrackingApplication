//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ProjectSeed : IEntityTypeConfiguration<Project>
//    {
//        public void Configure(EntityTypeBuilder<Project> builder)
//        {
//            builder.HasData(
//                   new Project
//                   {
//                       Id = Guid.NewGuid(),
//                       ProjectName = "TOGG_C_SUV",
//                       CustomerId = Guid.Parse("c77f95f6-d8cc-406b-8598-d32dc75969e8"),
//                       CreateDate = DateTime.Now,
//                       IsActive = true
//                   }

//                );
//        }
//    }
//}
