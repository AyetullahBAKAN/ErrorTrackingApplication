using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class partoperationmontage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("50ae565d-4a45-49ee-81f0-edab2d3902fc"));

            migrationBuilder.InsertData(
                table: "MontageLetter",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MontageNumber", "UpdateDate" },
                values: new object[] { new Guid("873f5156-1b3d-4201-b83c-dd5e9a172f71"), new DateTime(2024, 1, 15, 16, 33, 57, 106, DateTimeKind.Local).AddTicks(3913), null, true, false, null, null, "22AFN", null });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "OperationNo", "UpdateDate" },
                values: new object[] { new Guid("eb1d520d-da4e-4714-9a42-43cd0919d41c"), new DateTime(2024, 1, 15, 16, 33, 57, 106, DateTimeKind.Local).AddTicks(4172), null, true, false, null, null, "OP10_ACINIM", null });

            migrationBuilder.InsertData(
                table: "Part",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "PartNo", "UpdateDate" },
                values: new object[] { new Guid("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"), new DateTime(2024, 1, 15, 16, 33, 57, 106, DateTimeKind.Local).AddTicks(4298), null, true, false, null, null, "0203900021_22_", null });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "ProjectName", "UpdateDate" },
                values: new object[] { new Guid("b7954b9b-913b-46f9-b4cb-250ce9453343"), new DateTime(2024, 1, 15, 16, 33, 57, 106, DateTimeKind.Local).AddTicks(4435), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, "TOGG_C_SUV", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MontageLetter",
                keyColumn: "Id",
                keyValue: new Guid("873f5156-1b3d-4201-b83c-dd5e9a172f71"));

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: new Guid("eb1d520d-da4e-4714-9a42-43cd0919d41c"));

            migrationBuilder.DeleteData(
                table: "Part",
                keyColumn: "Id",
                keyValue: new Guid("403cf4a8-9e9f-4217-8b4f-a49c04ca13eb"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("b7954b9b-913b-46f9-b4cb-250ce9453343"));

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "ProjectName", "UpdateDate" },
                values: new object[] { new Guid("50ae565d-4a45-49ee-81f0-edab2d3902fc"), new DateTime(2024, 1, 15, 16, 28, 17, 62, DateTimeKind.Local).AddTicks(1075), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, "TOGG_C_SUV", null });
        }
    }
}
