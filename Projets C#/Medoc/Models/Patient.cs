using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Nom")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        [MaxLength(50)]
        public string Prenom { get; set; }

        public virtual ICollection<Fait> Faits { get; set; }
    }
}