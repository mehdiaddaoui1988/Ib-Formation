using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppMaladies.Models
{
    [Table("TBL_Risques")]
    public class Risque
    {


        [Key]
        [Column(name: "FK_Maladie", Order = 1)]
        public Guid IdMaladie { get; set; } = Guid.NewGuid();

        [Key]
        [Column(name: "FK_Fait", Order = 2)]
        public Guid IdFait { get; set; } = Guid.NewGuid();

        public double Probabilite { get; set; }

        [ForeignKey("IdMaladie")]
        public virtual Maladie Maladie { get; set; }

        [ForeignKey("IdFait")]
        public virtual Fait Fait { get; set; }
    }
}