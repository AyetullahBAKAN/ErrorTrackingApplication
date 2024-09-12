//using Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Repository.Seeds
//{
//    internal class OperationSeed : IEntityTypeConfiguration<Operation>
//    {
//        public void Configure(EntityTypeBuilder<Operation> builder)
//        {
//            builder.HasData(
//                new Operation
//                {
//                    Id = Guid.NewGuid(),
//                    OperationNo = "OP10_ACINIM",   //   togg
//                    CreateDate = DateTime.Now,
//                    IsActive = true
//                });
//        }
//    }
//}
