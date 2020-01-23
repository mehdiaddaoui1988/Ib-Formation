using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FirstApp.Models
{
    public class StatistiquesInitializer : DropCreateDatabaseIfModelChanges<StatistiquesContext>
    {
      
        protected override void Seed(StatistiquesContext context)
        {
            base.Seed(context);
            var q1 = new Question() { Text = "Aimez-vous les animaux ?" };
            context.Questions.Add(q1);

            var q2 = new Question() { Text = "Aimez-vous les rats ?" };
            context.Questions.Add(q2);

            var q3 = new Question() { Text = "Les rats sont-ils des animaux ?" };
            context.Questions.Add(q3);
          

            var u1 = new Utilisateur()
            {
                Mail = "toto@tata.fr",
                Nom = "Mauras",
                Prenom = "Milka",
                Password = SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes("123456"))
            };
  
            context.Utilisateurs.Add(u1);

            var u2 = new Utilisateur()
            {
                Mail = "rete@tata.fr",
                Nom = "Mauras",
                Prenom = "Olympe",
                Password = SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes("123456"))
            };
            context.Utilisateurs.Add(u2);

            for (var i = 0; i < 35; i++)
            {
                var u = new Utilisateur()
                {
                    Mail = "rete@tata.fr",
                    Nom = "Mauras",
                    Prenom = "Olympe",
                    Password = SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes("123456"))
                };
                context.Utilisateurs.Add(u);
            }


            var r1 = new Reponse()
            {
                Utilisateur = u1,
                Question = q1,
                Valeur = true

            };
            context.Reponses.Add(r1);
            var r2 = new Reponse()
            {
                Utilisateur = u1,
                IdQuestion = q2.Id,
                Valeur = true, 
                 

            };
            context.Reponses.Add(r2);
            var r3 = new Reponse()
            {
                Utilisateur = u2,
                IdQuestion = q2.Id,
                Valeur = false

            };
            context.Reponses.Add(r3);
            var r4 = new Reponse()
            {
                Utilisateur = u2,
                IdQuestion = q3.Id,
                Valeur = false

            };
            context.Reponses.Add(r4);
            context.SaveChanges();

        }
    }
}