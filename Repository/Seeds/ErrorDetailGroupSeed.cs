//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ErrorDetailGroupSeed : IEntityTypeConfiguration<ErrorDetailGroup>
//    {
//        public void Configure(EntityTypeBuilder<ErrorDetailGroup> builder)
//        {
//            builder.HasData(
//                new ErrorDetailGroup
//                {
//                    Id=Guid.NewGuid(),
//                    ErrorDetailGroupName="MARKALAMA/İZZIMBASI",
//                    IsActive = true,
//                    CreateDate = DateTime.Now,
//                },
//                new ErrorDetailGroup
//                {
//                    Id = Guid.NewGuid(),
//                    ErrorDetailGroupName = "DİĞER",
//                    IsActive = true,
//                    CreateDate = DateTime.Now,
//                });
//        }
//    }
//}
