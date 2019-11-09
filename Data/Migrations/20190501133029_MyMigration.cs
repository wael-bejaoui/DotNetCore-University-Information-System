using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_college.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClasseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    niveau = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    nbrPlace = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClasseId);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    EnseignantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cin = table.Column<string>(type: "nvarchar(250)", maxLength: 8, nullable: false),
                    nom = table.Column<string>(type: "nvarchar(250)", maxLength: 20, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(250)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.EnseignantId);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "nvarchar(250)", maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(250)", maxLength: 20, nullable: false),
                    cin = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.EtudiantId);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    SalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.SalleId);
                });

            migrationBuilder.CreateTable(
                name: "Enseignes",
                columns: table => new
                {
                    EnseigneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClasseId = table.Column<int>(nullable: false),
                    EnseignantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignes", x => x.EnseigneId);
                    table.ForeignKey(
                        name: "FK_Enseignes_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "ClasseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignes_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "EnseignantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 20, nullable: false),
                    EnseignantId = table.Column<int>(nullable: false),
                    SalleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CourId);
                    table.ForeignKey(
                        name: "FK_Cours_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "EnseignantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "SalleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EtudiantId = table.Column<int>(nullable: false),
                    CourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_Cours_CourId",
                        column: x => x.CourId,
                        principalTable: "Cours",
                        principalColumn: "CourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "EtudiantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CourId",
                table: "Absences",
                column: "CourId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EtudiantId",
                table: "Absences",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_SalleId",
                table: "Cours",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignes_ClasseId",
                table: "Enseignes",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignes_EnseignantId",
                table: "Enseignes",
                column: "EnseignantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Enseignes");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Salles");
        }
    }
}
