using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetVacances.DAL
{
    public class LancementsContext : DbContext
    {
        static LancementsContext()
        {
            Database.SetInitializer(new LancementsInitializer());
        }
        public DbSet<Fusee_DAO> Fusees { get; set; }
        public DbSet<Lancement_DAO> Lancements { get; set; }

    }
}