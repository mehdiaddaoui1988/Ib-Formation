using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    NumeroSiret = table.Column<string>(maxLength: 14, nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    NumeroTelephone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroFacture = table.Column<int>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    DateReglement = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IdClient = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdFacture = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestations_Factures_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "Nom", "NumeroSiret", "NumeroTelephone" },
                values: new object[] { new Guid("38263814-eb85-477c-9e0e-7d631c0433db"), "2 Rue du marathon", "decathlon@decathlon.com", "Decathlon", "KFEFE4864FE8E7", "0650408090" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "NumeroFacture" },
                values: new object[] { new Guid("1684d381-9138-4536-b1fc-847cc8bc200e"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 10, 54, 4, 901, DateTimeKind.Local).AddTicks(1558), "Tapis de course", new Guid("38263814-eb85-477c-9e0e-7d631c0433db"), 1 });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Nom" },
                values: new object[] { new Guid("7e63eb99-1359-42e7-82f2-9058ec677871"), "Nous dressons vos poules pour faire des oeufs carrés", new Guid("1684d381-9138-4536-b1fc-847cc8bc200e"), "Dressage de poules" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Nom" },
                values: new object[] { new Guid("73abeec2-34d5-43f3-a237-0386c66857d8"), "Nous vous fournissons l'élite", new Guid("1684d381-9138-4536-b1fc-847cc8bc200e"), "Location de tueurs à gage" });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_IdClient",
                table: "Factures",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Prestations_IdFacture",
                table: "Prestations",
                column: "IdFacture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
