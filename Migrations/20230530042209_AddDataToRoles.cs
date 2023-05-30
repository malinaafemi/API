using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("17886cc3-5ad9-4640-69db-08db60bf2967"), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1272), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1272), "Admin" },
                    { new Guid("2483b7c6-10bd-4ee4-69d9-08db60bf2967"), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1255), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1265), "User" },
                    { new Guid("6aaad8e7-364f-45d9-69da-08db60bf2967"), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1268), new DateTime(2023, 5, 30, 11, 22, 8, 887, DateTimeKind.Local).AddTicks(1269), "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("17886cc3-5ad9-4640-69db-08db60bf2967"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("2483b7c6-10bd-4ee4-69d9-08db60bf2967"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("6aaad8e7-364f-45d9-69da-08db60bf2967"));
        }
    }
}
