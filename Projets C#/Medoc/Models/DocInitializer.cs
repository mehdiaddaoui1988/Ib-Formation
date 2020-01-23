using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class DocInitializer : DropCreateDatabaseIfModelChanges<DocContext>
    {
        protected override void Seed(DocContext context)
        {
            base.Seed(context);
            var p1 = new Patient() { Nom = "Mauras", Prenom = "Dominique" };
            var p2 = new Patient() { Nom = "Mauras", Prenom = "Milka" };
            var p3 = new Patient() { Nom = "Mauras", Prenom = "Olympe" };
            context.Patients.Add(p1);
            context.Patients.Add(p2);
            context.Patients.Add(p3);

            var m1 = new Maladie() { Nom = "Rhume", Prescription = "Une saignée" };
            var m2 = new Maladie() { Nom = "Lèpre", Prescription = "Un cachou " };
            var m3 = new Maladie() { Nom = "Conjonctivite", Prescription = "Ablation de l'oeil" };
            var m4 = new Maladie() { Nom = "BPCO", Prescription = "Ablation du poumon" };
            context.Maladies.Add(m1);
            context.Maladies.Add(m2);
            context.Maladies.Add(m3); 
            context.Maladies.Add(m4);

            var f1 = new Fait() { Decsription = "Je tousse" };
            var f2 = new Fait() { Decsription = "J'ai le nez bouché" };
            var f3 = new Fait() { Decsription = "J'ai la larme à l'oeil" };
            var f4 = new Fait() { Decsription = "Je fume" };
            var f5 = new Fait() { Decsription = "Je suis tyrosémiophile" };
            context.Faits.Add(f1);
            context.Faits.Add(f2);
            context.Faits.Add(f3);
            context.Faits.Add(f4);
            context.Faits.Add(f5);

            var r1 = new Risque()
            {
                Maladie = m1,
                Fait = f1,
                Probabilite = 80
            };
            var r2 = new Risque()
            {
                Maladie = m1,
                Fait = f2,
                Probabilite = 80
            };
            var r3 = new Risque()
            {
                Maladie = m2,
                Fait = f3,
                Probabilite = 80
            };
            var r4 = new Risque()
            {
                Maladie = m4,
                Fait = f4,
                Probabilite = 80
            };
            var r5 = new Risque()
            {
                Maladie = m2,
                Fait = f1,
                Probabilite = 80
            };

            context.Risques.Add(r1);
            context.Risques.Add(r2);
            context.Risques.Add(r3);
            context.Risques.Add(r4);
            context.Risques.Add(r5);
            context.SaveChanges();

        }
    }
}