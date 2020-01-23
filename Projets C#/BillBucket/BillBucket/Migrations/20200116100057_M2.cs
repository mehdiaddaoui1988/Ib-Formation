using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("73abeec2-34d5-43f3-a237-0386c66857d8"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("7e63eb99-1359-42e7-82f2-9058ec677871"));

            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("1684d381-9138-4536-b1fc-847cc8bc200e"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("38263814-eb85-477c-9e0e-7d631c0433db"));

            migrationBuilder.AddColumn<double>(
                name: "Montant",
                table: "Prestations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "Nom", "NumeroSiret", "NumeroTelephone" },
                values: new object[] { new Guid("83147122-fc2b-4857-8087-abc84ec94b64"), "2 Rue du marathon", "decathlon@decathlon.com", "Decathlon", "KFEFE4864FE8E7", "0650408090" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "NumeroFacture" },
                values: new object[] { new Guid("3747b23b-d473-4b25-ab19-fc9125226816"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 11, 0, 56, 787, DateTimeKind.Local).AddTicks(8339), "Tapis de course", new Guid("83147122-fc2b-4857-8087-abc84ec94b64"), 1 });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("227cf6ce-9bc9-4d1b-8bdc-b97495b8bbd4"), "Nous dressons vos poules pour faire des oeufs carrés", new Guid("3747b23b-d473-4b25-ab19-fc9125226816"), 400.0, "Dressage de poules" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("f1eb2820-2c7a-4cea-8ee8-550dd30adbfb"), "Nous vous fournissons l'élite", new Guid("3747b23b-d473-4b25-ab19-fc9125226816"), 4000.0, "Location de tueurs à gage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("227cf6ce-9bc9-4d1b-8bdc-b97495b8bbd4"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("f1eb2820-2c7a-4cea-8ee8-550dd30adbfb"));

            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("3747b23b-d473-4b25-ab19-fc9125226816"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("83147122-fc2b-4857-8087-abc84ec94b64"));

            migrationBuilder.DropColumn(
                name: "Montant",
                table: "Prestations");

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
        }
    }
}
