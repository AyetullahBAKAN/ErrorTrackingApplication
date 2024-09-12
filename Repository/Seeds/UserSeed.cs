//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class UserSeed : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            builder.HasData(
//            new User
//            {
//                Id = Guid.NewGuid(),
//                Name="ibrahimmm",
//                SurName="yegenn",
//                Email = "ibrahim@gmail.com",
//                UserName = "ibrahim",
//                CreateDate = DateTime.Now,
//                IsActive = true,

//            },
//             new User
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "karahann",
//                 SurName = "turkerr",
//                 Email = "sample@gmail.com",
//                 UserName = "karahan",
//                 CreateDate = DateTime.Now,
//                 IsActive = true,

//             },
//              new User
//              {
//                  Id = Guid.NewGuid(),
//                  Name = "altugg",
//                  SurName = "akincii",
//                  Email = "sample@gmail.com",
//                  UserName = "altug",
//                  CreateDate = DateTime.Now,
//                  IsActive = true,

//              }); 
//        }
//    }
//}
