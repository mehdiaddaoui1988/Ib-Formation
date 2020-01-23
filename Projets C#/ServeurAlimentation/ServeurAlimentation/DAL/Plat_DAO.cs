using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    [Table("TBL_Plats")]
    public class Plat_DAO
    {
        [Key]
        [Column(name:"PK_Plat")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nom { get; set; }

        [MinLength(2)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Prix { get; set; } = 10000;

        public byte[] Photo { get; set; }

        // Un plat est associé à 0,1 ou plusieus instances de composition
        // Virtual va permettre au système de créer une classe qui hérite de Plat_DAO mais dont le get est modifié
        // pour renvoyer la liste des Composition_DAO trouvées en BDD
        public virtual ICollection<Composition_DAO> Compositions { get; set; }

    }
}