using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_college.Migrations
{
    public partial class migrationSalle123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbrPlace",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "nbrPlace",
                table: "Salles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nbrEtudiant",
                table: "Classes",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbrPlace",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "nbrEtudiant",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "nbrPlace",
                table: "Classes",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
