//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ErrorTypeSeed : IEntityTypeConfiguration<ErrorType>
//    {
//        public void Configure(EntityTypeBuilder<ErrorType> builder)
//        {
//            builder.HasData(new ErrorType
//            {
//                Id = Guid.NewGuid(),
//                UserId = Guid.Parse("e6ba61db-6206-4aa9-ea0d-08dc15a26e0a"),//ibrhmygn7787@gmail.com
//                ErrorMainTitleId = Guid.Parse("0040d100-e949-444d-aa63-3edd5accf96b"),//PROSES
//                ErrorSubGroupId = Guid.Parse("05de5f7b-8e09-4220-ada6-afecd02f5956"),//3dPROSES
//                ErrorDetailGroupId = Guid.Parse("3f48cc61-889b-4fdd-9bd5-987790298a65"),//DİGER
//                CreateDate = DateTime.Now,
//                IsActive = false,
//            });
//        }
//    }
//}
