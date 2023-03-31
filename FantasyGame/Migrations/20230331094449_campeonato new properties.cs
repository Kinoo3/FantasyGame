using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class campeonatonewproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRealizacao",
                table: "campeonatos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "campeonatos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRealizacao",
                table: "campeonatos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "campeonatos");
        }
    }
}
