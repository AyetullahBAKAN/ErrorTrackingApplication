using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "ErrorType",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorDetailGroupId", "ErrorMainTitleId", "ErrorSubGroupId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate", "UserId" },
                values: new object[] { new Guid("5d06e8f0-bc38-49d2-9e40-f296e70e33a0"), new DateTime(2024, 1, 17, 10, 46, 20, 594, DateTimeKind.Local).AddTicks(1004), null, new Guid("3f48cc61-889b-4fdd-9bd5-987790298a65"), new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956"), false, false, null, null, null, new Guid("e6ba61db-6206-4aa9-ea0d-08dc15a26e0a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorType",
                keyColumn: "Id",
                keyValue: new Guid("5d06e8f0-bc38-49d2-9e40-f296e70e33a0"));

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
    }
}
