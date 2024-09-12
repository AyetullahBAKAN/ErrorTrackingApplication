using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class applyConfigurationsFromAssembly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "ErrorDetectionLocation",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorLocation", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("028078ab-799b-453a-99f0-b4183c58af6a"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2520), null, "Proses", true, false, null, null, null },
                    { new Guid("03d97ea7-88a8-4b36-8225-fb3501850798"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2525), null, "Tasarım", true, false, null, null, null },
                    { new Guid("05a0fddb-acff-47f5-bfab-9727b90a5867"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2523), null, "SatınAlma", true, false, null, null, null },
                    { new Guid("4524cfbf-7c05-451a-8c1d-afaa58233e97"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2401), null, "Buy-Off", true, false, null, null, null },
                    { new Guid("48ef1020-ea09-4c07-99af-a5232b74081f"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2470), null, "Fason2DBüyük", true, false, null, null, null },
                    { new Guid("563306d8-b631-44ec-a2b2-02f6e5b3cad1"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2513), null, "ÖnMontaj", true, false, null, null, null },
                    { new Guid("756ee938-5ea0-4c30-a7ee-e36a807a8c59"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2482), null, "FinalMontaj", true, false, null, null, null },
                    { new Guid("7ae63932-c175-446a-9651-fc12ac3c3509"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2466), null, "CNC", true, false, null, null, null },
                    { new Guid("7c57324d-e6e5-4b31-a2d1-5ccbd0d1a365"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2499), null, "KalıpTedarik", true, false, null, null, null },
                    { new Guid("a0bfece1-aa27-4aca-b9f9-f16c5923b3ad"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2493), null, "HLTO", true, false, null, null, null },
                    { new Guid("afdbfeac-1c58-43e5-a7f0-f191e61d1637"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2515), null, "Pres", true, false, null, null, null },
                    { new Guid("b204f94b-2f5d-45d5-82a7-5f2a94dbe5c8"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2447), null, "CAM", true, false, null, null, null },
                    { new Guid("b3e0f767-cfc2-4c2a-aa6d-3c0996a0e227"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2476), null, "FasonCNC", true, false, null, null, null },
                    { new Guid("d7a7e88e-5c46-41ab-a076-23a775133fe8"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2502), null, "Kalite", true, false, null, null, null },
                    { new Guid("db8ba22b-4ec7-4b02-ae94-f7ff8e45167f"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2518), null, "Projeler", true, false, null, null, null },
                    { new Guid("e8106f1d-d5d5-4697-9dd3-64edf6151acb"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2508), null, "Metot", true, false, null, null, null },
                    { new Guid("ec799359-44e5-476f-a84e-22a681a23018"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2488), null, "GirişKalite", true, false, null, null, null },
                    { new Guid("ef36001c-8000-4c8e-bc7d-1bedfbf4ca3a"), new DateTime(2024, 1, 17, 9, 25, 32, 317, DateTimeKind.Local).AddTicks(2510), null, "Ölçüm", true, false, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("028078ab-799b-453a-99f0-b4183c58af6a"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("03d97ea7-88a8-4b36-8225-fb3501850798"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("05a0fddb-acff-47f5-bfab-9727b90a5867"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("4524cfbf-7c05-451a-8c1d-afaa58233e97"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("48ef1020-ea09-4c07-99af-a5232b74081f"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("563306d8-b631-44ec-a2b2-02f6e5b3cad1"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("756ee938-5ea0-4c30-a7ee-e36a807a8c59"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("7ae63932-c175-446a-9651-fc12ac3c3509"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("7c57324d-e6e5-4b31-a2d1-5ccbd0d1a365"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("a0bfece1-aa27-4aca-b9f9-f16c5923b3ad"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("afdbfeac-1c58-43e5-a7f0-f191e61d1637"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("b204f94b-2f5d-45d5-82a7-5f2a94dbe5c8"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("b3e0f767-cfc2-4c2a-aa6d-3c0996a0e227"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("d7a7e88e-5c46-41ab-a076-23a775133fe8"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("db8ba22b-4ec7-4b02-ae94-f7ff8e45167f"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("e8106f1d-d5d5-4697-9dd3-64edf6151acb"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("ec799359-44e5-476f-a84e-22a681a23018"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("ef36001c-8000-4c8e-bc7d-1bedfbf4ca3a"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
