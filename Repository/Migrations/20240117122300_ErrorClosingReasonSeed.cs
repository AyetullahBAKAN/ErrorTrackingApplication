using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorClosingReasonSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorClosingReason",
                keyColumn: "Id",   
                keyValue: new Guid("6f5986b9-cba8-4865-97cf-58a07f2202ff"));

            migrationBuilder.InsertData(
                table: "ErrorClosingReason",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "Reason", "UpdateDate" },
                values: new object[] { new Guid("b5ea940d-7e03-4150-ac79-115d81d70016"), new DateTime(2024, 1, 17, 15, 22, 58, 791, DateTimeKind.Local).AddTicks(4942), null, true, false, null, null, "Hatanın Sebebi", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorClosingReason",
                keyColumn: "Id",
                keyValue: new Guid("b5ea940d-7e03-4150-ac79-115d81d70016"));

            migrationBuilder.InsertData(
                table: "ErrorClosingReason",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "Reason", "UpdateDate" },
                values: new object[] { new Guid("6f5986b9-cba8-4865-97cf-58a07f2202ff"), new DateTime(2024, 1, 17, 15, 21, 58, 833, DateTimeKind.Local).AddTicks(9662), null, true, false, null, null, "Hatanın Sebebi", null });
        }
    }
}
