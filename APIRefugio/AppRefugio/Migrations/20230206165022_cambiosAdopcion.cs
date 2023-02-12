using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRefugio.Migrations
{
    public partial class cambiosAdopcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AnimalAdoptantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AnimalAdoptantes");
        }
    }
}
