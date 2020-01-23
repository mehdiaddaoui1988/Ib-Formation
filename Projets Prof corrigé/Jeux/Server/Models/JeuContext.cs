using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class JeuContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;Database=Jeux");
        }
        public DbSet<Partie> Parties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Partie>().HasKey(c => c.Id);

            modelBuilder.Entity<Partie>().HasData(new Partie()
            {
                Name = "Partie 1",
                Grid = new byte[100],
                SizeX=10,
                SizeY=10

            }); ; ;
        }
    }
}
