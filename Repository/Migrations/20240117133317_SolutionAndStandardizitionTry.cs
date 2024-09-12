using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SolutionAndStandardizitionTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SolutionAndStandardizition",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorClosingReasonId", "HowErrorClose", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "SolutionDetail", "SolutionPerma", "SolutionShort", "UpdateDate" },
                values: new object[] { new Guid("d6b7107a-c126-44f3-a265-6c3395c1a1b0"), new DateTime(2024, 1, 17, 16, 33, 16, 607, DateTimeKind.Local).AddTicks(5390), null, new Guid("b5ea940d-7e03-4150-ac79-115d81d70016"), "Hata Nasıl Kapatıldı", true, false, null, null, "Çözümün Detayı", "Kalıcı Çözüm", "Kısa Çözüm", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SolutionAndStandardizition",
                keyColumn: "Id",
                keyValue: new Guid("d6b7107a-c126-44f3-a265-6c3395c1a1b0"));

        }
    }
}
