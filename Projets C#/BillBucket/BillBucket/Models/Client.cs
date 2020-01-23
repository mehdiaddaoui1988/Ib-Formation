using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MinLength(3)]
        public string Nom { get; set; }

        [Required]
        [StringLength(maximumLength:14,MinimumLength =14)]
        [Display(Name ="Numéro de SIRET")]
        public string NumeroSiret { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Display(Name = "Numéro de téléphone")]
        public string NumeroTelephone { get; set; }

        [Display(Name = "Adresse mail")]
        public string Mail { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }
    }
}
