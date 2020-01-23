using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturation.Models;


namespace Facturation.Models
{
    public class FacturationContext : DbContext
    {
        public FacturationContext(DbContextOptions<FacturationContext> options):base(options)
        {
            //options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = Facturation; MultipleActiveResultSets = True; Trusted_Connection = True; ")
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Prestation> Prestations { get; set; }

        public IEnumerable<Operation> GetOperations()
        {
            var factures = this.Factures
                .Where(c => c.DateEdition!=null)
                .Select(c => new Operation()
            {
                Id = c.Id,
                IdClient = c.IdClient,

                Date = c.DateEcheance,
                Description = "Facture " + c.Numero,
                Action = "Details",
                Controller="Factures",
                RouteData=new { id=c.Id},
                Montant = c.MontantTTC
            });

             var paiements=   this.Paiements.Where(c => c.DateReception!=null).Select(c => new Operation()
            {
                Id = c.Id,
                IdClient=c.IdClient,
                Date = c.DateReception,
                Description = "Paiement " + c.Client.RaisonSociale,
                 Action = "Edit",
                 Controller = "Paiements",
                 RouteData = new { id = c.Id },
                 Montant = c.Montant
            });
            return factures.ToList().Union(paiements.ToList());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Add(new DecimalPropertyConvention(38, 18));
          
            modelBuilder.Entity<Client>(builder => {
               
                builder.HasKey(c => c.Id);
           
                builder.HasMany(c => c.Factures).WithOne(c => c.Client).HasForeignKey(c => c.IdClient);
                builder.HasMany(c => c.Paiements).WithOne(c => c.Client).HasForeignKey(c => c.IdClient);
            });
            modelBuilder.Entity<Paiement>(builder => {
                builder.HasKey(c => c.Id);
    
            });
            modelBuilder.Entity<Facture>(builder => {
                builder.HasKey(c => c.Id);
                builder.HasIndex(c => c.Numero).IsUnique();
                builder.HasMany(c => c.Prestations).WithOne(c => c.Facture).HasForeignKey(c => c.IdFacture);

            });
            modelBuilder.Entity<Paiement>(builder => {
                builder.HasKey(c => c.Id);
            });
            modelBuilder.Entity<Prestation>(builder => {

                builder.HasKey(c => c.Id);
                builder.Property(c => c.MontantHT).HasColumnType("Decimal(18,2)");
                builder.Property(c => c.TauxTVA).HasColumnType("Decimal(18,2)");

            });

            // Data
            //var c1 = new Client()
            //{
            //    RaisonSociale = "Ib",
            //    //Adresse = new Adresse() { Ligne1 = "1 Place de la Pyramide", CodePostal = "92911", Ville = "Paris La Défense CEDEX" },
            //    Mail="toto@toto.fr"
            //};
            //modelBuilder.Entity<Client>().HasData(c1);
            //var f1 = new Facture()
            //{
            //    Numero = "00001",
            //    Reference = "Devis 4566",
            //    IdClient = c1.Id
            //};
            //modelBuilder.Entity<Facture>().HasData(f1);
            //var p1 = new Prestation()
            //{
            //    Description = "Remise en état d'un store deffectueux",
            //    MontantHT = 100000,
            //    TauxTVA = 0.2M,
            //    IdFacture=f1.Id
            //};
            //modelBuilder.Entity<Prestation>().HasData(p1);
        }

   
    }
}
