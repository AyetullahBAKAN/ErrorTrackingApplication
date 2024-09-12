//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ErrorDefineSeed : IEntityTypeConfiguration<ErrorDefine>
//    {
//        public void Configure(EntityTypeBuilder<ErrorDefine> builder)
//        {
//            builder.HasData(new ErrorDefine
//            {
//                Id = Guid.NewGuid(),
//                ErrorExplain = "Hatanın Açıklaması",
//                CreateDate = DateTime.Now,
//                IsActive = true,
//            });
//        }
//    }
//}
