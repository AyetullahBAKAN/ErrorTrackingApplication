using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class fieldAndMoneySee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "Id", "CreateDate", "CreatedName", "FieldName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("835cfc09-d236-4c27-b592-7f867d3a5648"), new DateTime(2024, 1, 17, 11, 45, 28, 982, DateTimeKind.Local).AddTicks(3182), null, "KALİTE", true, false, null, null, null },
                    { new Guid("e3954137-829c-4cc0-b195-0df09a503226"), new DateTime(2024, 1, 17, 11, 45, 28, 982, DateTimeKind.Local).AddTicks(3180), null, "CNC", true, false, null, null, null },
                    { new Guid("f493550f-f6a6-4115-a2f1-d0b66ab498ec"), new DateTime(2024, 1, 17, 11, 45, 28, 982, DateTimeKind.Local).AddTicks(3165), null, "CAM", true, false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MoneyType",
                columns: new[] { "MoneyTypeId", "TypeOfMoney" },
                values: new object[,]
                {
                    { new Guid("397ce19e-1bea-42c7-9e2f-00389c61aa6b"), "DOLAR" },
                    { new Guid("61e2533c-2a85-4202-9c8e-edde41c9f3b2"), "LİRA" },
                    { new Guid("7697bccd-8ee4-4f40-881f-70bf80477671"), "EURO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("835cfc09-d236-4c27-b592-7f867d3a5648"));

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("e3954137-829c-4cc0-b195-0df09a503226"));

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: new Guid("f493550f-f6a6-4115-a2f1-d0b66ab498ec"));

            migrationBuilder.DeleteData(
                table: "MoneyType",
                keyColumn: "MoneyTypeId",
                keyValue: new Guid("397ce19e-1bea-42c7-9e2f-00389c61aa6b"));

            migrationBuilder.DeleteData(
                table: "MoneyType",
                keyColumn: "MoneyTypeId",
                keyValue: new Guid("61e2533c-2a85-4202-9c8e-edde41c9f3b2"));

            migrationBuilder.DeleteData(
                table: "MoneyType",
                keyColumn: "MoneyTypeId",
                keyValue: new Guid("7697bccd-8ee4-4f40-881f-70bf80477671"));
        }
    }
}
