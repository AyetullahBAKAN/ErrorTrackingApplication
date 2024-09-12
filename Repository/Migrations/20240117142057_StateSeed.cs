using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class StateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "StateAccept", "StateReject", "StateWait", "UpdateDate" },
                values: new object[] { new Guid("5e45933b-210d-4fd8-aea3-355bb9b905bc"), new DateTime(2024, 1, 17, 17, 20, 55, 505, DateTimeKind.Local).AddTicks(7054), null, true, false, null, null, "Kabul Edildi", "Reddedildi", "Beklemede", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: new Guid("5e45933b-210d-4fd8-aea3-355bb9b905bc"));
        }
    }
}
