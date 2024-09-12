using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class projectSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("9a0b7589-09da-4dce-866e-15d909028e48"));

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "ProjectName", "UpdateDate" },
                values: new object[] { new Guid("50ae565d-4a45-49ee-81f0-edab2d3902fc"), new DateTime(2024, 1, 15, 16, 28, 17, 62, DateTimeKind.Local).AddTicks(1075), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, "TOGG_C_SUV", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("50ae565d-4a45-49ee-81f0-edab2d3902fc"));

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "ProjectName", "UpdateDate" },
                values: new object[] { new Guid("9a0b7589-09da-4dce-866e-15d909028e48"), new DateTime(2024, 1, 15, 16, 27, 0, 660, DateTimeKind.Local).AddTicks(5781), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, "TOGG_C_SUV", null });
        }
    }
}
