using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    public class RecettesInitializer : CreateDatabaseIfNotExists<RecettesContext>
    {
        protected override void Seed(RecettesContext context)
        {
            base.Seed(context);

            var p1 = new Plat_DAO()
            {
                Nom = "Lasagnes au saumon",
                Description = "C'est vraiment délicieux le saumon.",
            };
            var p2 = new Plat_DAO()
            {
                Nom = "Couscous",
                Description = "Vive la semoule.",
            };
            var p3 = new Plat_DAO()
            {
                Nom = "Salade de fruits",
                Description = "Jolie jolie.",
            };
            context.Plats.Add(p1);
            context.Plats.Add(p2);
            context.Plats.Add(p3);

            context.SaveChanges();
        }
    }
}