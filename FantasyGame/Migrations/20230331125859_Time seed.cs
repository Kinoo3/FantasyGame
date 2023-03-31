using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class Timeseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 500, "Internacional" },
                    { 501, "São paulo" },
                    { 502, "Flamengo" },
                    { 503, "Santos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 503);
        }
    }
}
