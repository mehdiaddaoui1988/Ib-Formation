using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FirstApp.Models
{
    public class StatistiquesContext : DbContext
    {

        static StatistiquesContext()
        {
            // Association de l'initializer au context
            Database.SetInitializer<StatistiquesContext>(new StatistiquesInitializer());
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Utilisation de fluent api pour établir les relations dans la base de données

            modelBuilder.Entity<Question>()
                    .ToTable("Tbl_Questions")
                    .HasKey(c=>c.Id)
                    .HasMany(c => c.Reponses)
                    .WithRequired(c => c.Question)
                    .HasForeignKey(c => c.IdQuestion)
                    .WillCascadeOnDelete(true);

            // Changeent de nom pour la colonne Id de l'utilisateur
            modelBuilder.Entity<Question>().Property(c => c.Id)
                    .HasColumnName("Pk_Question");

            // Clé primaire composée de deux Foreign Keys
            modelBuilder.Entity<Reponse>().HasKey(c => new
            {
                 c.IdUtilisateur,
                 c.IdQuestion
            });

        }

    }
}