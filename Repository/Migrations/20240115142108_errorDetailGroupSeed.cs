using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class errorDetailGroupSeed : Migration
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
                table: "ErrorDetailGroup",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorDetailGroupName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("113b72d8-0760-4769-a397-fac29f17ca09"), new DateTime(2024, 1, 15, 17, 21, 5, 825, DateTimeKind.Local).AddTicks(7752), null, "MARKALAMA/İZZIMBASI", true, false, null, null, null },
                    { new Guid("3f48cc61-889b-4fdd-9bd5-987790298a65"), new DateTime(2024, 1, 15, 17, 21, 5, 825, DateTimeKind.Local).AddTicks(7767), null, "DİĞER", true, false, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDetailGroup",
                keyColumn: "Id",
                keyValue: new Guid("113b72d8-0760-4769-a397-fac29f17ca09"));

            migrationBuilder.DeleteData(
                table: "ErrorDetailGroup",
                keyColumn: "Id",
                keyValue: new Guid("3f48cc61-889b-4fdd-9bd5-987790298a65"));

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
