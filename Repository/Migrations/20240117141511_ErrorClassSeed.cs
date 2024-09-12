using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorClassSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "ErrorClass",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorMainTitleId", "ErrorSubGroupId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "ShortDetail", "UpdateDate" },
                values: new object[] { new Guid("5824119e-9ae7-4786-ba03-8b8786cf88fe"), new DateTime(2024, 1, 17, 17, 15, 9, 787, DateTimeKind.Local).AddTicks(9795), null, new Guid("0040d100-e949-444d-aa63-3edd5accf96b"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956"), true, false, null, null, "İşlem Sırasında Yapılan Hatadan Dolayı Arıza Oluşmuştur", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorClass",
                keyColumn: "Id",
                keyValue: new Guid("5824119e-9ae7-4786-ba03-8b8786cf88fe"));

        }
    }
}
