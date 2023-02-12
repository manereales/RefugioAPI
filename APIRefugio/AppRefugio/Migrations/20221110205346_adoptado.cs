using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRefugio.Migrations
{
    public partial class adoptado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Adoptado",
                table: "Animales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adoptado",
                table: "Animales");
        }
    }
}
