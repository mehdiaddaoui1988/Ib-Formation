using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DTO
{
    public class Plat_DTO
    { 
        public Guid i { get; set; }

        public string n { get; set; }

        public string d { get; set; }

        public decimal? p { get; set; }
    }
}