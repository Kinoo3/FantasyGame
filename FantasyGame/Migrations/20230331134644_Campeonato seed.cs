using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class Campeonatoseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "campeonatos",
                columns: new[] { "Id", "DataRealizacao", "Nome" },
                values: new object[] { 1000, new DateTime(2023, 1, 1, 19, 34, 13, 856, DateTimeKind.Unspecified).AddTicks(690), "Brasileirão" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "campeonatos",
                keyColumn: "Id",
                keyValue: 1000);
        }
    }
}
