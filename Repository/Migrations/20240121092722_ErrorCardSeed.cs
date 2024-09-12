using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorCardSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "ErrorCard",
                columns: new[] { "Id", "CostId", "CreateDate", "CreatedName", "DateFinish", "DateStart", "ErrorClassId", "ErrorDefineId", "ErrorDetectionLocationId", "FormNumber", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "PageNumber", "PatternId", "RevNumber", "RootAnalysisId", "SolutionAndStandardizitionId", "StateId", "UnitId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("96fba1db-522e-46b4-8066-4ddddcf8b0bd"), new Guid("0c3aba21-2e4a-4c5a-8bcd-2baef73a8306"), new DateTime(2024, 1, 21, 12, 27, 17, 384, DateTimeKind.Local).AddTicks(6146), null, new DateTime(2024, 1, 21, 12, 27, 17, 384, DateTimeKind.Local).AddTicks(6131), new DateTime(2024, 1, 21, 12, 27, 17, 384, DateTimeKind.Local).AddTicks(6107), new Guid("5824119e-9ae7-4786-ba03-8b8786cf88fe"), new Guid("7a21f2d5-d9ac-47bf-8653-36474ab1cbb6"), new Guid("da34c50e-0039-4bb9-a89b-24015e457182"), "1A", true, false, null, null, 1, new Guid("b0e2c25d-a4af-4e0d-bf60-4f5aaad9c2e9"), 1, new Guid("52001537-8daf-450e-b9c9-fe5793ba3ed2"), new Guid("d6b7107a-c126-44f3-a265-6c3395c1a1b0"), new Guid("5e45933b-210d-4fd8-aea3-355bb9b905bc"), new Guid("cad2b84f-b68e-4c38-94be-bedd9fc9d254"), null, new Guid("e6ba61db-6206-4aa9-ea0d-08dc15a26e0a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorCard",
                keyColumn: "Id",
                keyValue: new Guid("96fba1db-522e-46b4-8066-4ddddcf8b0bd"));

        }
    }
}
