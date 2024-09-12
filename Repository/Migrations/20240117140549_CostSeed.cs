using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class CostSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Cost",
                columns: new[] { "Id", "Amount", "CreateDate", "CreatedName", "Description", "FieldId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MoneyTypeId", "Time", "UpdateDate" },
                values: new object[] { new Guid("0c3aba21-2e4a-4c5a-8bcd-2baef73a8306"), 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama", new Guid("e3954137-829c-4cc0-b195-0df09a503226"), true, false, null, null, new Guid("7697bccd-8ee4-4f40-881f-70bf80477671"), 10.0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cost",
                keyColumn: "Id",
                keyValue: new Guid("0c3aba21-2e4a-4c5a-8bcd-2baef73a8306"));

            
        }
    }
}
