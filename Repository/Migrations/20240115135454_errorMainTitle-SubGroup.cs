using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
   
    public partial class errorMainTitleSubGroup : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pattern",
                keyColumn: "Id",
                keyValue: new Guid("fe49a4e3-2883-4b9f-b8c6-5a50dc32a14f"));

            migrationBuilder.InsertData(
                table: "ErrorMainTitle",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorMainTitleName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[] { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new DateTime(2024, 1, 15, 16, 54, 52, 383, DateTimeKind.Local).AddTicks(9110), null, "PROSES", true, false, null, null, null });

            migrationBuilder.InsertData(
                table: "ErrorSubGroup",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorSubGroupName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956"), new DateTime(2024, 1, 15, 16, 54, 52, 383, DateTimeKind.Local).AddTicks(9991), null, "3DPROSES", true, false, null, null, null },
                    { new Guid("2aae2fb2-812e-42ab-a233-ae2211cc8b18"), new DateTime(2024, 1, 15, 16, 54, 52, 383, DateTimeKind.Local).AddTicks(9995), null, "3DİŞLEMEDATASI", true, false, null, null, null },
                    { new Guid("ed0f96fe-3953-4440-a190-56cfcbe047c2"), new DateTime(2024, 1, 15, 16, 54, 52, 383, DateTimeKind.Local).AddTicks(9983), null, "FİZİBİLİTE", true, false, null, null, null }
                });
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorMainTitle",
                keyColumn: "Id",
                keyValue: new Guid("0040d100-e949-444d-aa63-3edd5accf96b"));

            migrationBuilder.DeleteData(
                table: "ErrorSubGroup",
                keyColumn: "Id",
                keyValue: new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956"));

            migrationBuilder.DeleteData(
                table: "ErrorSubGroup",
                keyColumn: "Id",
                keyValue: new Guid("2aae2fb2-812e-42ab-a233-ae2211cc8b18"));

            migrationBuilder.DeleteData(
                table: "ErrorSubGroup",
                keyColumn: "Id",
                keyValue: new Guid("ed0f96fe-3953-4440-a190-56cfcbe047c2"));

            migrationBuilder.InsertData(
                table: "Pattern",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MontageLetterId", "OperationId", "PartId", "ProjectId", "UpdateDate" },
                values: new object[] { new Guid("fe49a4e3-2883-4b9f-b8c6-5a50dc32a14f"), new DateTime(2024, 1, 15, 16, 39, 0, 875, DateTimeKind.Local).AddTicks(5836), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, new Guid("873f5156-1b3d-4201-b83c-dd5e9a172f71"), new Guid("eb1d520d-da4e-4714-9a42-43cd0919d41c"), new Guid("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"), new Guid("b7954b9b-913b-46f9-b4cb-250ce9453343"), null });

        }
    }
}
