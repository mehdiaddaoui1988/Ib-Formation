using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scolarite.Models
{
    public class Eleve
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name="Nom")]
        [Required]
        [MaxLength(50)]
        [MinLength(2, ErrorMessage ="Le {0} doit avoir au moins {1} charactères")]
        public string Nom { get; set; }


        [Display(Name = "Prénom")]
        [Required]
        [MaxLength(50)]
        [MinLength(2, ErrorMessage = "Le {0} doit avoir au moins {1} charactères")]
        public string Prenom { get; set; }

        [DisplayFormat(DataFormatString = "{0}", NullDisplayText = "---")]
        public string Remarque { get; set; }


        [Display(Name = "Date de naissance")]
        [Required]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",NullDisplayText ="---")]
        public DateTime DateNaissance { get; set; }

        // Un élève peut avoir plusieurs évaluations
        public virtual ICollection<Evaluation> Evaluations { get; set; }


    }
}
