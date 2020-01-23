using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AppMaladies.Models.enums;

namespace AppMaladies.Models
{
    public class DoctorInitializer : DropCreateDatabaseIfModelChanges<DoctorContext>
    {
        protected override void Seed(DoctorContext context)
        {
            base.Seed(context);

            var m1 = new Maladie()
            {
                Intitule = "Rhume",
                Gravite = Gravite.Benin
            };
            var m2 = new Maladie()
            {
                Intitule = "SIDA",
                Gravite = Gravite.RIP
            };
            var m3 = new Maladie()
            {
                Intitule = "Alzheimer",
                Gravite = Gravite.Grave
            };
            var m4 = new Maladie()
            {
                Intitule = "Parkinson",
                Gravite = Gravite.RIP
            };
            var m5 = new Maladie()
            {
                Intitule = "Asthme",
                Gravite = Gravite.Modere
            };
            var m6 = new Maladie()
            {
                Intitule = "Varicelle",
                Gravite = Gravite.Grave
            };
            var m7 = new Maladie()
            {
                Intitule = "Tuberculose",
                Gravite = Gravite.Grave
            };
            var m8 = new Maladie()
            {
                Intitule = "Cancer du poumon",
                Gravite = Gravite.Grave
            };
            var m9 = new Maladie()
            {
                Intitule = "Gastro-Entérite",
                Gravite = Gravite.Grave
            };
            var m10 = new Maladie()
            {
                Intitule = "Tchernobilite aiguë",
                Gravite = Gravite.Grave
            };

            context.Maladies.Add(m1);
            context.Maladies.Add(m2);
            context.Maladies.Add(m3);
            context.Maladies.Add(m4);
            context.Maladies.Add(m5);
            context.Maladies.Add(m6);
            context.Maladies.Add(m7);
            context.Maladies.Add(m8);
            context.Maladies.Add(m9);
            context.Maladies.Add(m10);



            var f1 = new Fait()
            {
                Intitule = "Maux de gorge"
            };
            var f2 = new Fait()
            {
                Intitule = "Diarrhées"
            };
            var f3 = new Fait()
            {
                Intitule = "Maux de tête"
            };
            var f4 = new Fait()
            {
                Intitule = "Fumeur"
            };
            var f5 = new Fait()
            {
                Intitule = "Douleur thoracique"
            };
            var f6 = new Fait()
            {
                Intitule = "Ganglions enflés"
            };
            var f7 = new Fait()
            {
                Intitule = "Sécrétions de fluides nasaux"
            };
            var f8 = new Fait()
            {
                Intitule = "Éruptions cutanées"
            };
            var f9 = new Fait()
            {
                Intitule = "Luminosensibilité"
            };
            var f10 = new Fait()
            {
                Intitule = "Nausées"
            };
            var f11 = new Fait()
            {
                Intitule = "Perte de l'ouïe"
            };
            var f12 = new Fait()
            {
                Intitule = "Irritations"
            };
            var f13 = new Fait()
            {
                Intitule = "Difficultés respiratoires"
            };
            var f14 = new Fait()
            {
                Intitule = "Toux"
            };
            var f15 = new Fait()
            {
                Intitule = "Mange de l'uranium enrichi"
            };
            var f16 = new Fait()
            {
                Intitule = "Démence passagère"
            };
            var f17 = new Fait()
            {
                Intitule = "Insomnie"
            };
            var f18 = new Fait()
            {
                Intitule = "Perte de connaissance"
            };
            var f19 = new Fait()
            {
                Intitule = "Perte de poids"
            };
            var f20 = new Fait()
            {
                Intitule = "Prise de drogues"
            };

            context.Faits.Add(f1);
            context.Faits.Add(f2);
            context.Faits.Add(f3);
            context.Faits.Add(f4);
            context.Faits.Add(f5);
            context.Faits.Add(f6);
            context.Faits.Add(f7);
            context.Faits.Add(f8);
            context.Faits.Add(f9);
            context.Faits.Add(f10);
            context.Faits.Add(f11);
            context.Faits.Add(f12);
            context.Faits.Add(f13);
            context.Faits.Add(f14);
            context.Faits.Add(f15);
            context.Faits.Add(f16);
            context.Faits.Add(f17);
            context.Faits.Add(f18);
            context.Faits.Add(f19);
            context.Faits.Add(f20);



            var r1 = new Risque()
            {
                Fait = f1,
                Maladie = m1,
                Probabilite = 0.3
            };


            context.SaveChanges();


        }
    }
}