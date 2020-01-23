using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class Risque
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Maladie")]
        [Index("IX_Unique", IsUnique =true, Order =1)]
        public Guid IdMaladie { get; set; }

        [Display(Name = "Fait")]
        [Index("IX_Unique",IsUnique = true, Order = 2)]
        public Guid IdFait { get; set; } 


        [Display(Name="Probabilité")]
        public int Probabilite { get; set; }

        public virtual Maladie Maladie { get; set; }
        public virtual Fait Fait { get; set; }


    }
}