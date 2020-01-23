using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServeurAlimentation.DAL
{
    // L'attribut Table permet de spécifier le nom de la table
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
  
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Range(minimum: 0, maximum: 10000)]
        public decimal? Prix { get; set; } = 10000;

        // Un plat est associé à 0,1 ou plusieurs instances de composition
        // Virtual va permettre au système de créer une classe 
        // Qui hérité de Plat_DAO
        // Mais dont le get est modifié
        // Pour renvoyer la liste des Composition_DAO trouvées dans la base de données
        public virtual ICollection<Composition_DAO> Compositions { get; set; }

        public byte[] Photo { get; set; }


    }
}