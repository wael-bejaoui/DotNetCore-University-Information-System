using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_college.Migrations
{
    public partial class type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Salles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salles_TypeId",
                table: "Salles",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Type_TypeId",
                table: "Salles",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Type_TypeId",
                table: "Salles");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Salles_TypeId",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Salles");
        }
    }
}
