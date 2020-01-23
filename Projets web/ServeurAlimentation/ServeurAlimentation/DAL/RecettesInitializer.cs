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
                Description = "Des jolies lasagnes que Sabrina nous apportera à la rentrée",
            };
            context.Plats.Add(p1);

            var p2 = new Plat_DAO()
            {
                Nom = "Haricots verts mayonnaise",
                Description = "flljfksdlk kfkdsf jlksd jfl jksdlk fljksjldkf jklsdfjl skjlf jsdf jkjlks dfj",
            };
            context.Plats.Add(p2);
            context.SaveChanges();
        }
    }
}