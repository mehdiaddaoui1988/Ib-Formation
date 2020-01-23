using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "Nom", "NumeroSiret", "NumeroTelephone" },
                values: new object[] { new Guid("99c9d537-ea92-4d84-8b0d-584f4374f4fc"), "2 Rue du marathon", "decathlon@decathlon.com", "Decathlon", "KFEFE4864FE8E7", "0650408090" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "NumeroFacture" },
                values: new object[] { new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), "Tapis de course", new Guid("99c9d537-ea92-4d84-8b0d-584f4374f4fc"), 1 });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("2b043369-3b14-4022-ad57-3f564a7cc2b2"), "Nous dressons vos poules pour faire des oeufs carrés", new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"), 400.0, "Dressage de poules" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("01b3b566-d064-44ea-b2e6-9583100a7ad7"), "Nous vous fournissons l'élite", new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"), 4000.0, "Location de tueurs à gage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("01b3b566-d064-44ea-b2e6-9583100a7ad7"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("2b043369-3b14-4022-ad57-3f564a7cc2b2"));

            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("99c9d537-ea92-4d84-8b0d-584f4374f4fc"));

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
    }
}
