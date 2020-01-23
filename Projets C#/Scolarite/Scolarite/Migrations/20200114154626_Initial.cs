using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scolarite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(maxLength: 50, nullable: false),
                    Remarque = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    IdEleve = table.Column<Guid>(nullable: false),
                    IdMatiere = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Appreciation = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => new { x.IdEleve, x.IdMatiere, x.Date });
                    table.ForeignKey(
                        name: "FK_Evaluations_Eleves_IdEleve",
                        column: x => x.IdEleve,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Matieres_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eleves",
                columns: new[] { "Id", "DateNaissance", "Nom", "Prenom", "Remarque" },
                values: new object[,]
                {
                    { new Guid("76ad27ec-9d1a-4d89-ac48-94af895a2867"), new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauras", "Milka", null },
                    { new Guid("aebb766b-2488-4f46-b181-35d633df6bd5"), new DateTime(2002, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauras", "Olympe", null }
                });

            migrationBuilder.InsertData(
                table: "Matieres",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { new Guid("e334db08-43db-43b6-8e4e-454912c1b780"), "Mathématiques" },
                    { new Guid("85450685-2b78-480a-9908-b8cf228acca8"), "Français" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_IdMatiere",
                table: "Evaluations",
                column: "IdMatiere");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Matieres");
        }
    }
}
