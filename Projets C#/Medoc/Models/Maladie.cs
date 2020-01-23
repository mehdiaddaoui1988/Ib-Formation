using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class Maladie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Display(Name = "Nom")]
        [MaxLength(200)]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Prescription")]
        [MaxLength(200)]


        public string Prescription { get; set; }

        public virtual ICollection<Risque> Risques { get; set; }
    }
}