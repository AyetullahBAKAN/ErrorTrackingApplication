using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDefine",
                keyColumn: "Id",
                keyValue: new Guid("3c4e729b-a6c2-4eb3-942f-f13144bac2c8"));

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ImagePath", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[] { new Guid("d659a1ce-e757-4efb-a828-1478bed96db7"), new DateTime(2024, 1, 17, 15, 3, 45, 340, DateTimeKind.Local).AddTicks(4217), null, "dosya yolu eklenecek", true, false, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("d659a1ce-e757-4efb-a828-1478bed96db7"));

            migrationBuilder.InsertData(
                table: "ErrorDefine",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorExplain", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[] { new Guid("3c4e729b-a6c2-4eb3-942f-f13144bac2c8"), new DateTime(2024, 1, 17, 15, 0, 53, 926, DateTimeKind.Local).AddTicks(7033), null, "Hatanın Açıklaması", true, false, null, null, null });
        }
    }
}
