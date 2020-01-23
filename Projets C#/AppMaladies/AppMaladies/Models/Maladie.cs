using AppMaladies.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppMaladies.Models
{
    [Table("TBL_Maladies")]

    public class Maladie
    {
        [Key]
        [Column("PK_Maladie")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Intitule { get; set; }

        public Gravite Gravite { get; set; }

        public virtual ICollection<Risque> Risques { get; set; }
    }
}