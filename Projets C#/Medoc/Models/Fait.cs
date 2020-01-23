using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medoc.Models
{
    public class Fait
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name ="Description")]
        [MaxLength(200)]
        public string Decsription { get; set; }

        public virtual ICollection<Risque> Risques { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}