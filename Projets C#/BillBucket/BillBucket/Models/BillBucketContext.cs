using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class BillBucketContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=BillBucketDB;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Prestation> Prestations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Facture>().HasKey(c => c.Id);
            modelBuilder.Entity<Prestation>().HasKey(c => c.Id);



            modelBuilder.Entity<Client>()
                .HasMany(c => c.Factures)
                .WithOne(c => c.Client)
                .HasForeignKey(c=>c.IdClient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Facture>()
                .HasMany(c => c.Prestations)
                .WithOne(c => c.Facture)
                .HasForeignKey(c => c.IdFacture)
                .OnDelete(DeleteBehavior.Cascade);



            var c1 = new Client()
            {
                Nom = "Decathlon",
                Mail = "decathlon@decathlon.com",
                NumeroSiret = "KFEFE4864FE8E7",
                Adresse = "2 Rue du marathon",
                NumeroTelephone = "0650408090"
            };
            var f1 = new Facture()
            {
                DateEmission = new DateTime(2020, 01, 01),
                NumeroFacture = 1,
                DateReglement = DateTime.Now,
                Description = "Tapis de course",
                IdClient = c1.Id
            };
            var p1 = new Prestation()
            {
                Nom = "Dressage de poules",
                Description = "Nous dressons vos poules pour faire des oeufs carrés",
                Montant = 400,
                IdFacture = f1.Id
            };
            var p2 = new Prestation()
            {
                Nom = "Location de tueurs à gage",
                Description = "Nous vous fournissons l'élite",
                Montant = 4000,
                IdFacture = f1.Id
                
            };
            


            modelBuilder.Entity<Client>().HasData(c1);
            modelBuilder.Entity<Prestation>().HasData(p1,p2);
            modelBuilder.Entity<Facture>().HasData(f1);

        }
    }
}
