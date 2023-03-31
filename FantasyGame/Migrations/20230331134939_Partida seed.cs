using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class Partidaseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Partidas",
                columns: new[] { "Id", "CampeonatoId", "Data", "Time1Gols", "Time1Id", "Time2Gols", "Time2Id" },
                values: new object[,]
                {
                    { 500, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 3, 500, 2, 501 },
                    { 501, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 2, 500, 3, 502 },
                    { 502, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 1, 500, 1, 503 },
                    { 503, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 5, 501, 4, 502 },
                    { 504, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 4, 501, 2, 503 },
                    { 505, 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), 3, 502, 1, 503 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Partidas",
                keyColumn: "Id",
                keyValue: 505);
        }
    }
}
