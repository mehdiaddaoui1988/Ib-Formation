using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scolarite.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Eleves",
                keyColumn: "Id",
                keyValue: new Guid("76ad27ec-9d1a-4d89-ac48-94af895a2867"));

            migrationBuilder.DeleteData(
                table: "Eleves",
                keyColumn: "Id",
                keyValue: new Guid("aebb766b-2488-4f46-b181-35d633df6bd5"));

            migrationBuilder.DeleteData(
                table: "Matieres",
                keyColumn: "Id",
                keyValue: new Guid("85450685-2b78-480a-9908-b8cf228acca8"));

            migrationBuilder.DeleteData(
                table: "Matieres",
                keyColumn: "Id",
                keyValue: new Guid("e334db08-43db-43b6-8e4e-454912c1b780"));

            migrationBuilder.InsertData(
                table: "Eleves",
                columns: new[] { "Id", "DateNaissance", "Nom", "Prenom", "Remarque" },
                values: new object[,]
                {
                    { new Guid("652c7fe5-1b08-478e-9fb3-3adaaec2e8bc"), new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauras", "Milka", null },
                    { new Guid("cc3cbdec-7907-4c99-8003-12f108256206"), new DateTime(2002, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauras", "Olympe", null }
                });

            migrationBuilder.InsertData(
                table: "Matieres",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { new Guid("3b018172-0593-4f52-ab0c-760ad24c4eb4"), "Mathématiques" },
                    { new Guid("1c54e7eb-f728-47c2-98b6-2593d6465ef6"), "Français" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Eleves",
                keyColumn: "Id",
                keyValue: new Guid("652c7fe5-1b08-478e-9fb3-3adaaec2e8bc"));

            migrationBuilder.DeleteData(
                table: "Eleves",
                keyColumn: "Id",
                keyValue: new Guid("cc3cbdec-7907-4c99-8003-12f108256206"));

            migrationBuilder.DeleteData(
                table: "Matieres",
                keyColumn: "Id",
                keyValue: new Guid("1c54e7eb-f728-47c2-98b6-2593d6465ef6"));

            migrationBuilder.DeleteData(
                table: "Matieres",
                keyColumn: "Id",
                keyValue: new Guid("3b018172-0593-4f52-ab0c-760ad24c4eb4"));

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
        }
    }
}
