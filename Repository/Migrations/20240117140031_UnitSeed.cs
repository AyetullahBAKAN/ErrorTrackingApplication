using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnitSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UnitName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("47219b50-7349-4305-9c1c-a40d1c91dace"), new DateTime(2024, 1, 17, 17, 0, 30, 12, DateTimeKind.Local).AddTicks(325), null, true, false, null, null, "BİLGİ İŞLEM", null },
                    { new Guid("7fc6827c-d903-42fd-a27e-2419cc3498d8"), new DateTime(2024, 1, 17, 17, 0, 30, 12, DateTimeKind.Local).AddTicks(326), null, true, false, null, null, "CNC", null },
                    { new Guid("cad2b84f-b68e-4c38-94be-bedd9fc9d254"), new DateTime(2024, 1, 17, 17, 0, 30, 12, DateTimeKind.Local).AddTicks(312), null, true, false, null, null, "PROSES", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("47219b50-7349-4305-9c1c-a40d1c91dace"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7fc6827c-d903-42fd-a27e-2419cc3498d8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("cad2b84f-b68e-4c38-94be-bedd9fc9d254"));

        }
    }
}
