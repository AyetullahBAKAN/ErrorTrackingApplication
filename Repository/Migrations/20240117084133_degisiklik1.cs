using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class degisiklik1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RootAnalysis",
                keyColumn: "Id",
                keyValue: new Guid("665d247f-e632-4720-8da2-f29b8ec32560"));

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfMoney",
                table: "MoneyType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,4)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Cost",
                type: "decimal(16,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TypeOfMoney",
                table: "MoneyType",
                type: "decimal(16,4)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Cost",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,4)");

            migrationBuilder.InsertData(
                table: "RootAnalysis",
                columns: new[] { "Id", "CreateDate", "CreatedName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "Result", "UpdateDate", "WhyOne", "WhyRoot", "WhyThree", "WhyTwo" },
                values: new object[] { new Guid("665d247f-e632-4720-8da2-f29b8ec32560"), new DateTime(2024, 1, 17, 11, 10, 9, 793, DateTimeKind.Local).AddTicks(4761), null, true, false, null, null, "Sonuç", null, "SebepBir", "HataninKökü", "SebepUç", "Sebepİki" });
        }
    }
}
