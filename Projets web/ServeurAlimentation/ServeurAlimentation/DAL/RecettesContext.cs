using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    public class RecettesContext : DbContext
    {
        static RecettesContext()
        {
            Database.SetInitializer(new RecettesInitializer());
        }
        // Table dans la BDD
        public DbSet<Plat_DAO> Plats { get; set; }
        public DbSet<Ingredient_DAO> Ingredients { get; set; }
        public DbSet<Composition_DAO> Compositions { get; set; }

 

    }
}