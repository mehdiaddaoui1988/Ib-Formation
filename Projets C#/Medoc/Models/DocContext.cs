using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class DocContext : DbContext
    {
        static DocContext()
        {
            Database.SetInitializer(new DocInitializer());
        }
        public DbSet<Maladie> Maladies { get; set; }
        public DbSet<Fait> Faits { get; set; }
        public DbSet<Risque> Risques { get; set; }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Risque>().HasKey(c => c.Id);
            modelBuilder.Entity<Patient>().HasMany(c => c.Faits).WithMany(c => c.Patients);
            modelBuilder.Entity<Maladie>().HasMany(c => c.Risques).WithRequired(c => c.Maladie).HasForeignKey(c => c.IdMaladie).WillCascadeOnDelete(true);
            modelBuilder.Entity<Fait>().HasMany(c => c.Risques).WithRequired(c => c.Fait).HasForeignKey(c => c.IdFait).WillCascadeOnDelete(true);
        }

      }
}