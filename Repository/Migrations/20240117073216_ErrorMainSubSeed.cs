using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorMainSubSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pattern",
                keyColumn: "Id",
                keyValue: new Guid("45d5ef56-891b-4992-8107-decb4d051675"));

            migrationBuilder.InsertData(
                table: "ErrorMainSub",
                columns: new[] { "ErrorMainTitleId", "ErrorSubGroupId" },
                values: new object[,]
                {
                    { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") },
                    { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("2aae2fb2-812e-42ab-a233-ae2211cc8b18") },
                    { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("ed0f96fe-3953-4440-a190-56cfcbe047c2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorMainSub",
                keyColumns: new[] { "ErrorMainTitleId", "ErrorSubGroupId" },
                keyValues: new object[] { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") });

            migrationBuilder.DeleteData(
                table: "ErrorMainSub",
                keyColumns: new[] { "ErrorMainTitleId", "ErrorSubGroupId" },
                keyValues: new object[] { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("2aae2fb2-812e-42ab-a233-ae2211cc8b18") });

            migrationBuilder.DeleteData(
                table: "ErrorMainSub",
                keyColumns: new[] { "ErrorMainTitleId", "ErrorSubGroupId" },
                keyValues: new object[] { new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("ed0f96fe-3953-4440-a190-56cfcbe047c2") });

            migrationBuilder.InsertData(
                table: "Pattern",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MontageLetterId", "OperationId", "PartId", "ProjectId", "UpdateDate" },
                values: new object[] { new Guid("45d5ef56-891b-4992-8107-decb4d051675"), new DateTime(2024, 1, 17, 9, 50, 43, 502, DateTimeKind.Local).AddTicks(5657), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, new Guid("873f5156-1b3d-4201-b83c-dd5e9a172f71"), new Guid("eb1d520d-da4e-4714-9a42-43cd0919d41c"), new Guid("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"), new Guid("b7954b9b-913b-46f9-b4cb-250ce9453343"), null });
        }
    }
}
