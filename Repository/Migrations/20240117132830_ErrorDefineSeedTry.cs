using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorDefineSeedTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ErrorDefine",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorExplain", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[] { new Guid("7a21f2d5-d9ac-47bf-8653-36474ab1cbb6"), new DateTime(2024, 1, 17, 16, 28, 27, 854, DateTimeKind.Local).AddTicks(5504), null, "Hatanın Açıklaması", true, false, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDefine",
                keyColumn: "Id",
                keyValue: new Guid("7a21f2d5-d9ac-47bf-8653-36474ab1cbb6"));
        }
    }
}
