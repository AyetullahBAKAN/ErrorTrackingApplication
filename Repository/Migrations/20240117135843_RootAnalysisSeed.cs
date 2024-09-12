using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RootAnalysisSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "RootAnalysis",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "Result", "UpdateDate", "WhyOne", "WhyRoot", "WhyThree", "WhyTwo" },
                values: new object[] { new Guid("52001537-8daf-450e-b9c9-fe5793ba3ed2"), new DateTime(2024, 1, 17, 16, 58, 41, 917, DateTimeKind.Local).AddTicks(3915), null, true, false, null, null, "Sonuç", null, "SebepBir", "HataninKökü", "SebepUç", "Sebepİki" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RootAnalysis",
                keyColumn: "Id",
                keyValue: new Guid("52001537-8daf-450e-b9c9-fe5793ba3ed2"));

        }
    }
}
