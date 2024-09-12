//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ErrorSubGroupSeed : IEntityTypeConfiguration<ErrorSubGroup>
//    {
//        public void Configure(EntityTypeBuilder<ErrorSubGroup> builder)
//        {
//            builder.HasData(
//                new ErrorSubGroup
//                {
//                    Id=Guid.NewGuid(),
//                    ErrorSubGroupName="FİZİBİLİTE",
//                    IsActive=true,
//                    CreateDate = DateTime.Now,
//                },
//                new ErrorSubGroup
//                {
//                    Id = Guid.NewGuid(),
//                    ErrorSubGroupName = "3DPROSES",
//                    IsActive = true,
//                    CreateDate = DateTime.Now,
//                },
//                new ErrorSubGroup
//                {
//                    Id = Guid.NewGuid(),
//                    ErrorSubGroupName = "3DİŞLEMEDATASI",
//                    IsActive = true,
//                    CreateDate = DateTime.Now,
//                });
//        }
//    }
//}
