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
//    internal class ErrorClassSeed : IEntityTypeConfiguration<ErrorClass>
//    {
//        public void Configure(EntityTypeBuilder<ErrorClass> builder)
//        {
//            builder.HasData(new ErrorClass
//            {
//                Id = Guid.NewGuid(),
//                ErrorMainTitleId = Guid.Parse("0040D100-E949-444D-AA63-3EDD5ACCF96B"),//PROSES
//                ErrorSubGroupId = Guid.Parse("05DE5F7B-8E09-4220-ADA6-AFECD02F5956"), //3DPROSES
//                ShortDetail = "İşlem Sırasında Yapılan Hatadan Dolayı Arıza Oluşmuştur",//kısa detay
//                CreateDate = DateTime.Now,
//                IsActive = true,
//            });
//        }
//    }
//}
