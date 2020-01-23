using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppMaladies.Models
{
    [Table("TBL_Faits")]

    public class Fait
    {
        [Key]
        [Column("PK_Fait")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Intitule { get; set; }

        public virtual ICollection<Risque> Risques { get; set; }
    }
}