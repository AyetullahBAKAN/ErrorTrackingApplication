//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Seeds
//{
//    internal class CostSeed : IEntityTypeConfiguration<Cost>
//    {
//        public void Configure(EntityTypeBuilder<Cost> builder)
//        {
//            builder.HasData(new Cost
//            {
//                Id=Guid.NewGuid(),
//                FieldId=Guid.Parse("E3954137-829C-4CC0-B195-0DF09A503226"), //CNC
//                MoneyTypeId=Guid.Parse("7697BCCD-8EE4-4F40-881F-70BF80477671"), //EURO
//                Description="Açıklama",
//                Time=10,
//                Amount=100,
//                CreateDate=DateTime.Now,
//                IsActive=true,
//            });
//        }
//    }
//}
