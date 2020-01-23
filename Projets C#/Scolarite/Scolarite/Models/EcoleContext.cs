using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scolarite.Models
{
    public class EcoleContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ScolariteDB;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Clé de Eleve
            modelBuilder.Entity<Eleve>().HasKey(c => c.Id);
            // Clé de Matiere
            modelBuilder.Entity<Matiere>().HasKey(c => c.Id);
            // Clé de Evaluation
            modelBuilder.Entity<Evaluation>().HasKey(c =>new { c.IdEleve,c.IdMatiere, c.Date });

            // Relation 1-n entre Eleve et Evaluations
            modelBuilder.Entity<Eleve>().HasMany(c => c.Evaluations)
                                        .WithOne(c => c.Eleve)
                                        .HasForeignKey(c=>c.IdEleve)
                                        .OnDelete(DeleteBehavior.Cascade);
            // Relation 1-n entre Matiere et Evaluations
            modelBuilder.Entity<Matiere>()
                            .HasMany(c => c.Evaluations)
                            .WithOne(c => c.Matiere)
                            .HasForeignKey(c => c.IdMatiere)
                            .OnDelete(DeleteBehavior.Cascade);


            // Insertion des données initiales dans la BDD

            // Matières
            var m1 = new Matiere() { Nom = "Mathématiques" };
            var m2 = new Matiere() { Nom = "Français" };
            modelBuilder.Entity<Matiere>().HasData(m1, m2);

            // Eleves
            var e1 = new Eleve() { Nom = "Mauras", 
                                    Prenom = "Milka", 
                                    DateNaissance = new DateTime(2000, 10, 1) };
            var e2 = new Eleve() { Nom = "Mauras", 
                                    Prenom = "Olympe", 
                                    DateNaissance = new DateTime(2002, 10, 1) };
            modelBuilder.Entity<Eleve>().HasData(e1, e2);

            // Evaluations
        //    var a1 = new Evaluation() { Eleve = e1, Matiere = m1, Note = 20 };
           // modelBuilder.Entity<Evaluation>().HasData(a1);

            //modelBuilder.Entity<Evaluation>()
            //        .HasOne(c=>c.Matiere)
            //        .WithMany(c=>c.Evaluations)
            //        .OnDelete(DeleteBehavior.Cascade)
        }
    }
}
