using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorDetectionLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ErrorDetectionLocation",
                columns: new[] { "Id", "CreateDate", "CreatedName", "ErrorLocation", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("13e3913a-13f5-49ce-8d01-f6338c9d795f"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7545), null, "Projeler", true, false, null, null, null },
                    { new Guid("2a853e95-5a8d-4395-a872-1b9a127de78b"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7536), null, "Metot", true, false, null, null, null },
                    { new Guid("2e3d9858-387b-4aa9-a563-ab020754aa0b"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7525), null, "HLTO", true, false, null, null, null },
                    { new Guid("2ee9f419-b17c-41e7-a79e-738b8976c7f5"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7543), null, "Pres", true, false, null, null, null },
                    { new Guid("2f4379c4-0590-4116-a81a-adf3759c9a5a"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7516), null, "FasonCNC", true, false, null, null, null },
                    { new Guid("37e7f46c-40c1-4387-9cfd-c1edf8ae4da1"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7550), null, "SatınAlma", true, false, null, null, null },
                    { new Guid("6f89283e-798c-49ee-b91c-eab50ca5bffd"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7539), null, "Ölçüm", true, false, null, null, null },
                    { new Guid("7e298b8d-da6f-4b5e-9172-67319c06674c"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7527), null, "KalıpTedarik", true, false, null, null, null },
                    { new Guid("9cca1f96-3a6d-465e-ac62-e1f9ff0f7fb2"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7541), null, "ÖnMontaj", true, false, null, null, null },
                    { new Guid("a3c369b9-2cb8-4c46-b11a-3513f3d4dcb3"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7489), null, "CAM", true, false, null, null, null },
                    { new Guid("af8bc754-f9d3-4ae8-b400-856f0e212e42"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7514), null, "Fason2DBüyük", true, false, null, null, null },
                    { new Guid("ba07f2cc-4ccf-434c-9187-b469f16b7b85"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7521), null, "GirişKalite", true, false, null, null, null },
                    { new Guid("c94a38a0-bc14-44b0-b37c-b6e3fcf2e73d"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7530), null, "Kalite", true, false, null, null, null },
                    { new Guid("d11fab91-6150-4238-8e3d-c1440a40ace2"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7464), null, "Buy-Off", true, false, null, null, null },
                    { new Guid("d60100bf-7db6-4c65-b6d6-d5e33865843b"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7511), null, "CNC", true, false, null, null, null },
                    { new Guid("da34c50e-0039-4bb9-a89b-24015e457182"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7548), null, "Proses", true, false, null, null, null },
                    { new Guid("dc33b84f-830e-4135-8190-d379a7db7f00"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7553), null, "Tasarım", true, false, null, null, null },
                    { new Guid("f9f315b4-22a2-4adc-bb3a-c497d1eb31b2"), new DateTime(2024, 1, 17, 16, 52, 13, 503, DateTimeKind.Local).AddTicks(7518), null, "FinalMontaj", true, false, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("13e3913a-13f5-49ce-8d01-f6338c9d795f"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("2a853e95-5a8d-4395-a872-1b9a127de78b"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("2e3d9858-387b-4aa9-a563-ab020754aa0b"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("2ee9f419-b17c-41e7-a79e-738b8976c7f5"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("2f4379c4-0590-4116-a81a-adf3759c9a5a"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("37e7f46c-40c1-4387-9cfd-c1edf8ae4da1"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("6f89283e-798c-49ee-b91c-eab50ca5bffd"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("7e298b8d-da6f-4b5e-9172-67319c06674c"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("9cca1f96-3a6d-465e-ac62-e1f9ff0f7fb2"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("a3c369b9-2cb8-4c46-b11a-3513f3d4dcb3"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("af8bc754-f9d3-4ae8-b400-856f0e212e42"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("ba07f2cc-4ccf-434c-9187-b469f16b7b85"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("c94a38a0-bc14-44b0-b37c-b6e3fcf2e73d"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("d11fab91-6150-4238-8e3d-c1440a40ace2"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("d60100bf-7db6-4c65-b6d6-d5e33865843b"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("da34c50e-0039-4bb9-a89b-24015e457182"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("dc33b84f-830e-4135-8190-d379a7db7f00"));

            migrationBuilder.DeleteData(
                table: "ErrorDetectionLocation",
                keyColumn: "Id",
                keyValue: new Guid("f9f315b4-22a2-4adc-bb3a-c497d1eb31b2"));
        }
    }
}
