using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    [Table("TBL_Ingredients")]
    public class Ingredient_DAO
    {
        [Key]
        [Column("PK_Ingredient")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nom { get; set; }
        public bool? ContientGluten { get; set; }
        public bool? EstBio { get; set; }


        public virtual ICollection<Composition_DAO> Compositions { get; set; }

        public byte[] Photo { get; set; }
    }
}