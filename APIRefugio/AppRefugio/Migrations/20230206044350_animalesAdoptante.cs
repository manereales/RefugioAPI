using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRefugio.Migrations
{
    public partial class animalesAdoptante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptantes_Animales_AnimalesId",
                table: "Adoptantes");

            migrationBuilder.DropIndex(
                name: "IX_Adoptantes_AnimalesId",
                table: "Adoptantes");

            migrationBuilder.DropColumn(
                name: "AnimalesId",
                table: "Adoptantes");

            migrationBuilder.CreateTable(
                name: "AnimalAdoptantes",
                columns: table => new
                {
                    AnimalesId = table.Column<int>(type: "int", nullable: false),
                    AdoptanteId = table.Column<int>(type: "int", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalAdoptantes", x => new { x.AdoptanteId, x.AnimalesId });
                    table.ForeignKey(
                        name: "FK_AnimalAdoptantes_Adoptantes_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "Adoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalAdoptantes_Animales_AnimalesId",
                        column: x => x.AnimalesId,
                        principalTable: "Animales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalAdoptantes_AnimalesId",
                table: "AnimalAdoptantes",
                column: "AnimalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalAdoptantes");

            migrationBuilder.AddColumn<int>(
                name: "AnimalesId",
                table: "Adoptantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptantes_AnimalesId",
                table: "Adoptantes",
                column: "AnimalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptantes_Animales_AnimalesId",
                table: "Adoptantes",
                column: "AnimalesId",
                principalTable: "Animales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
