using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppMaladies.Models
{
    public class DoctorContext : DbContext
    {
        static DoctorContext()
        {
            // Association de l'initializer au context
            Database.SetInitializer<DoctorContext>(new DoctorInitializer());
        }
        public DbSet<Fait> Faits { get; set; }
        public DbSet<Risque> Risques { get; set; }
        public DbSet<Maladie> Maladies { get; set; }

    }
}