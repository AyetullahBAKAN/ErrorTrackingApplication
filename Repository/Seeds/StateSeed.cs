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
//    internal class StateSeed : IEntityTypeConfiguration<State>
//    {
//        public void Configure(EntityTypeBuilder<State> builder)
//        {
//            builder.HasData(new State
//            {
//                Id=Guid.NewGuid(),
//                StateAccept="Kabul Edildi",
//                StateWait="Beklemede",
//                StateReject="Reddedildi",
//                CreateDate=DateTime.Now,
//                IsActive=true,
//            });
//        }
//    }
//}
