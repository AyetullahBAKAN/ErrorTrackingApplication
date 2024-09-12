using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class PatternSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Pattern",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MontageLetterId", "OperationId", "PartId", "ProjectId", "UpdateDate" },
                values: new object[] { new Guid("b0e2c25d-a4af-4e0d-bf60-4f5aaad9c2e9"), new DateTime(2024, 1, 17, 16, 55, 34, 179, DateTimeKind.Local).AddTicks(8191), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, new Guid("873f5156-1b3d-4201-b83c-dd5e9a172f71"), new Guid("eb1d520d-da4e-4714-9a42-43cd0919d41c"), new Guid("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"), new Guid("b7954b9b-913b-46f9-b4cb-250ce9453343"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pattern",
                keyColumn: "Id",
                keyValue: new Guid("b0e2c25d-a4af-4e0d-bf60-4f5aaad9c2e9"));

           
        }
    }
}
