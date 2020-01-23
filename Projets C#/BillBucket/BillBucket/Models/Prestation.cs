using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Prestation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        public double Montant { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public Guid IdFacture { get; set; }
        public virtual Facture Facture { get; set; }
    }
}
