using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class Createdcampeonatopartida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time1Id = table.Column<int>(type: "int", nullable: false),
                    Time1Gols = table.Column<int>(type: "int", nullable: false),
                    Time2Id = table.Column<int>(type: "int", nullable: false),
                    Time2Gols = table.Column<int>(type: "int", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_Time1Id",
                        column: x => x.Time1Id,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_Time2Id",
                        column: x => x.Time2Id,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_CampeonatoId",
                table: "Partidas",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_Time1Id",
                table: "Partidas",
                column: "Time1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_Time2Id",
                table: "Partidas",
                column: "Time2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "campeonatos");
        }
    }
}
