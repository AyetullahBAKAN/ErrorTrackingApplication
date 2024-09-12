using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class errorDefineSees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MediaErrorDefine",
                keyColumns: new[] { "ErrorDefineId", "MediaId" },
                keyValues: new object[] { new Guid("05b94f28-6bb3-4320-996d-eca82f9b88cf"), new Guid("b3cd63de-95f3-402a-8404-cfb8b5f69db5") });

            migrationBuilder.InsertData(
                table: "ErrorDefine",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorExplain", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[] { new Guid("3c4e729b-a6c2-4eb3-942f-f13144bac2c8"), new DateTime(2024, 1, 17, 15, 0, 53, 926, DateTimeKind.Local).AddTicks(7033), null, "Hatanın Açıklaması", true, false, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDefine",
                keyColumn: "Id",
                keyValue: new Guid("3c4e729b-a6c2-4eb3-942f-f13144bac2c8"));

            migrationBuilder.InsertData(
                table: "MediaErrorDefine",
                columns: new[] { "ErrorDefineId", "MediaId" },
                values: new object[] { new Guid("05b94f28-6bb3-4320-996d-eca82f9b88cf"), new Guid("b3cd63de-95f3-402a-8404-cfb8b5f69db5") });
        }
    }
}
