using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetVacances.DAL
{
    public class LancementsInitializer : DropCreateDatabaseAlways<LancementsContext>
    {
        protected override void Seed(LancementsContext context)
        {
            base.Seed(context);

            var f1 = new Fusee_DAO()
            {
                Entreprise = "SpaceX",
                Modele = "Falcon 9",
                NombreDeVols = 0
            };

            var f2 = new Fusee_DAO()
            {
                Entreprise = "SpaceX",
                Modele = "Falcon Heavy",
                NombreDeVols = 2
            };

            var l1 = new Lancement_DAO()
            {
                DateLancement = DateTime.Parse("04/01/2020"),
                ChargeUtile = "60 Starlink version 1 satellites",
                PoidsChargeUtile = 15400,
                EtatAtterrissage = EnumEtatAtterrissage.Prévu.ToString(),
                DescriptionMission = "SpaceX's first flight of 2020 will launch the second batch of Starlink version 1 satellites into orbit aboard a Falcon 9 rocket.",
                Fusee = f1
            };

            var l2 = new Lancement_DAO()
            {
                DateLancement = DateTime.Parse("06/02/2018"),
                ChargeUtile = "Elon's midnight cherry Tesla Roadster",
                PoidsChargeUtile = 1305,
                EtatAtterrissage =  EnumEtatAtterrissage.Reussite.ToString(),
                DescriptionMission = "SpaceX's test flight of Falcon Heavy. Core stage landing not successful, side core landings successful. Vehicle is sucessfully put to orbit.",
                Fusee = f2
            };

            context.Fusees.Add(f1);
            context.Fusees.Add(f2);
            context.SaveChanges();

            context.Lancements.Add(l1);
            context.Lancements.Add(l2);
            context.SaveChanges();

        }
    }
}