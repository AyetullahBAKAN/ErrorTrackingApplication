//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class MoneyTypeSeed : IEntityTypeConfiguration<MoneyType>
//    {
//        public void Configure(EntityTypeBuilder<MoneyType> builder)
//        {
//            builder.HasData(
//                new MoneyType
//                {
//                    MoneyTypeId = Guid.NewGuid(),
//                    TypeOfMoney = "EURO",
//                },
//                 new MoneyType
//                 {
//                     MoneyTypeId = Guid.NewGuid(),
//                     TypeOfMoney = "DOLAR",
//                 },
//                  new MoneyType
//                  {
//                      MoneyTypeId = Guid.NewGuid(),
//                      TypeOfMoney = "LİRA",
//                  });
//        }
//    }
//}
