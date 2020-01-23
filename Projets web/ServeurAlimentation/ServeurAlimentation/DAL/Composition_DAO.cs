using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    [Table("TBL_Compositions")]
    public class Composition_DAO
    {
        [Key]

        [Column("FK_Plat",Order=1)]
        public Guid IdPlat { get; set; }

        [Key]
        [Column("FK_Ingredient", Order = 2)]
        public Guid IdIngredient { get; set; }

        [Range(0,Double.MaxValue)]
        public decimal Poids { get; set; }

        public virtual Plat_DAO Plat { get; set; }
        public virtual Ingredient_DAO Ingredient { get; set; }

    }
}