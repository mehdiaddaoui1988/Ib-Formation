using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroazApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroazSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NiveauDeBins = table.Column<int>(nullable: false),
                    Trut = table.Column<string>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    IdParain = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroazSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroazSet_GroazSet_IdParain",
                        column: x => x.IdParain,
                        principalTable: "GroazSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GroazSet",
                columns: new[] { "Id", "DateNaissance", "IdParain", "NiveauDeBins", "Trut" },
                values: new object[] { new Guid("2c6773d4-02a4-4a70-96e6-98f28dc8c0a5"), new DateTime(1908, 10, 9, 12, 22, 12, 0, DateTimeKind.Unspecified), null, 3, "Braz pizza" });

            migrationBuilder.InsertData(
                table: "GroazSet",
                columns: new[] { "Id", "DateNaissance", "IdParain", "NiveauDeBins", "Trut" },
                values: new object[] { new Guid("2d4ff6cf-ae3f-4fde-b3a5-f08d352e1491"), new DateTime(2020, 1, 23, 10, 17, 57, 469, DateTimeKind.Local).AddTicks(8683), new Guid("2c6773d4-02a4-4a70-96e6-98f28dc8c0a5"), 5, "Papa pizza" });

            migrationBuilder.CreateIndex(
                name: "IX_GroazSet_IdParain",
                table: "GroazSet",
                column: "IdParain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroazSet");
        }
    }
}
