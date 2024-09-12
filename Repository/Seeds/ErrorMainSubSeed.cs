//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class ErrorMainSubSeed : IEntityTypeConfiguration<ErrorMainSub>
//    {
//        public void Configure(EntityTypeBuilder<ErrorMainSub> builder)
//        {
//            builder.HasData(
//                new ErrorMainSub
//                {
//                    ErrorMainTitleId = Guid.Parse("0040d100-e949-444d-aa63-3edd5accf96b"),//proses
//                    ErrorSubGroupId = Guid.Parse("ed0f96fe-3953-4440-a190-56cfcbe047c2"), //FİZİBİLİTE

//                },
//                new ErrorMainSub
//                {
//                    ErrorMainTitleId = Guid.Parse("0040d100-e949-444d-aa63-3edd5accf96b"),//proses
//                    ErrorSubGroupId = Guid.Parse("2aae2fb2-812e-42ab-a233-ae2211cc8b18") // 3DİŞLEMEDATASI
//                },
//               new ErrorMainSub
//               {
//                   ErrorMainTitleId = Guid.Parse("0040d100-e949-444d-aa63-3edd5accf96b"),//proses
//                   ErrorSubGroupId = Guid.Parse("05de5f7b-8e09-4220-ada6-afecd02f5956") //3DPROSES
//               }
//               );
//        }
//    }
//}
