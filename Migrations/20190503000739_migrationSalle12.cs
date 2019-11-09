using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_college.Migrations
{
    public partial class migrationSalle12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Type_TypeId",
                table: "Salles");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Type",
                newName: "SalleTypeId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Salles",
                newName: "SalleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Salles_TypeId",
                table: "Salles",
                newName: "IX_Salles_SalleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Type_SalleTypeId",
                table: "Salles",
                column: "SalleTypeId",
                principalTable: "Type",
                principalColumn: "SalleTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Type_SalleTypeId",
                table: "Salles");

            migrationBuilder.RenameColumn(
                name: "SalleTypeId",
                table: "Type",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "SalleTypeId",
                table: "Salles",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Salles_SalleTypeId",
                table: "Salles",
                newName: "IX_Salles_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Type_TypeId",
                table: "Salles",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
