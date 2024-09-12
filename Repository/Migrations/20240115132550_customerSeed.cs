using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class customerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pattern",
                keyColumn: "Id",
                keyValue: new Guid("55830588-379d-48fa-b508-3be68fd14138"));

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerName", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("007588ba-ef52-4583-a251-0a27e4e8f5b2"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7494), null, "PSA", true, false, null, null, null },
                    { new Guid("04a3a688-c5ea-4baa-a7b2-cc0ad12df037"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7492), null, "OPEL", true, false, null, null, null },
                    { new Guid("2620d80d-fddb-462d-aebb-51af42e26747"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7500), null, "SEAT", true, false, null, null, null },
                    { new Guid("2f231608-5c40-4ded-8513-e8b9bc7538aa"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7469), null, "DAİMLER", true, false, null, null, null },
                    { new Guid("47dc0293-b6fc-4cb7-8ad3-b9bcf7230d75"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7490), null, "NİSSAN", true, false, null, null, null },
                    { new Guid("657b2b55-4682-4fb6-9755-660661928d9c"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7497), null, "RENAULT", true, false, null, null, null },
                    { new Guid("6fcc4dff-6fc2-4e29-9f61-a1a8ecf63f3d"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7467), null, "FİAT", true, false, null, null, null },
                    { new Guid("746482df-b337-4f8c-9250-05e19bc058d1"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7474), null, "FORD", true, false, null, null, null },
                    { new Guid("7a2720fe-5be4-4840-bb50-805a137b4834"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7507), null, "VW", true, false, null, null, null },
                    { new Guid("83b35e1e-cfea-4899-903c-e715e574df7a"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7503), null, "TOYOTA", true, false, null, null, null },
                    { new Guid("97a9b53f-ef6f-4c6e-9fdc-4295341ce214"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7488), null, "TOGG", true, false, null, null, null },
                    { new Guid("b18a43ad-c73a-4e6c-a6f8-c97b659a1231"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7498), null, "TOFAŞ", true, false, null, null, null },
                    { new Guid("df7bd9f0-8d0a-4fe5-8156-afdb2047cca3"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7452), null, "BMC", true, false, null, null, null },
                    { new Guid("e9e8a861-a1bf-4d2e-a243-1b6aff9eb79e"), new DateTime(2024, 1, 15, 16, 25, 48, 201, DateTimeKind.Local).AddTicks(7472), null, "MAN", true, false, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("007588ba-ef52-4583-a251-0a27e4e8f5b2"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("04a3a688-c5ea-4baa-a7b2-cc0ad12df037"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("2620d80d-fddb-462d-aebb-51af42e26747"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("2f231608-5c40-4ded-8513-e8b9bc7538aa"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("47dc0293-b6fc-4cb7-8ad3-b9bcf7230d75"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("657b2b55-4682-4fb6-9755-660661928d9c"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("6fcc4dff-6fc2-4e29-9f61-a1a8ecf63f3d"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("746482df-b337-4f8c-9250-05e19bc058d1"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("7a2720fe-5be4-4840-bb50-805a137b4834"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("83b35e1e-cfea-4899-903c-e715e574df7a"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("97a9b53f-ef6f-4c6e-9fdc-4295341ce214"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("b18a43ad-c73a-4e6c-a6f8-c97b659a1231"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("df7bd9f0-8d0a-4fe5-8156-afdb2047cca3"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("e9e8a861-a1bf-4d2e-a243-1b6aff9eb79e"));

            migrationBuilder.InsertData(
                table: "Pattern",
                columns: new[] { "Id", "CreateDate", "CreatedName", "CustomerId", "IsActive", "IsDeleted", "LastModifiedById", "LastModifiedName", "MontageLetterId", "OperationId", "PartId", "ProjectId", "UpdateDate" },
                values: new object[] { new Guid("55830588-379d-48fa-b508-3be68fd14138"), new DateTime(2024, 1, 15, 16, 17, 43, 707, DateTimeKind.Local).AddTicks(8625), null, new Guid("c77f95f6-d8cc-406b-8598-d32dc75969e8"), true, false, null, null, new Guid("bdfc569b-dd91-4d72-b054-6da97fcf42d1"), new Guid("bddd3cb0-4167-4e96-884c-21abcf6a4eba"), new Guid("67ea9d60-e676-4fae-9838-f90916e25823"), new Guid("8be6556e-ce51-422a-b8e8-f5f41a39fc07"), null });
        }
    }
}
