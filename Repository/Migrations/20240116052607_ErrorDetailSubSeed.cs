using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ErrorDetailSubSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDetailSub",
                keyColumns: new[] { "ErrorDetailGroupId", "ErrorSubGroupId" },
                keyValues: new object[] { new Guid("113b72d8-0760-4769-a397-fac29f17ca09"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") });

            migrationBuilder.InsertData(
                table: "ErrorDetailSub",
                columns: new[] { "ErrorDetailGroupId", "ErrorSubGroupId" },
                values: new object[] { new Guid("3f48cc61-889b-4fdd-9bd5-987790298a65"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorDetailSub",
                keyColumns: new[] { "ErrorDetailGroupId", "ErrorSubGroupId" },
                keyValues: new object[] { new Guid("3f48cc61-889b-4fdd-9bd5-987790298a65"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") });

            migrationBuilder.InsertData(
                table: "ErrorDetailSub",
                columns: new[] { "ErrorDetailGroupId", "ErrorSubGroupId" },
                values: new object[] { new Guid("113b72d8-0760-4769-a397-fac29f17ca09"), new Guid("05de5f7b-8e09-4220-ada6-afecd02f5956") });
        }
    }
}
