using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DTO
{
    public class Ingredient_DTO
    {
        public Guid i { get; set; }
        public string n { get; set; }
        public bool? cg { get; set; }
        public bool? eb { get; set; }
    }
}