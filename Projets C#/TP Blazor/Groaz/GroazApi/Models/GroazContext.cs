using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroazApi.Models
{
    public class GroazContext : DbContext
    {
        //private IConfiguration configuration;

        //public GroazContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public GroazContext(DbContextOptions<GroazContext> options):base(options)
        {

        }
     
        public DbSet<Groaz> GroazSet { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           //optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("GroazDatabase"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Groaz>().HasKey(c => c.Id);
            modelBuilder.Entity<Groaz>()
                    .HasMany(c => c.FilleulSet)
                    .WithOne(c => c.Parain)
                    .HasForeignKey(c => c.IdParain);


            var g1 = new Groaz()
            {
                NiveauDeBins = 3,
                Trut = "Braz pizza",
                DateNaissance=new DateTime(1908,10,9,12,22,12)
            };
            var g2 = new Groaz()
            {
                NiveauDeBins = 5,
                Trut = "Papa pizza",
                IdParain=g1.Id
            };
            modelBuilder.Entity<Groaz>().HasData(g1,g2);
        }

    }
}
