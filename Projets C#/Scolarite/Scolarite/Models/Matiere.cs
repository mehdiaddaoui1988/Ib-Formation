using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scolarite.Models
{
    public class Matiere
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Nom")]
        [Required]
        [MaxLength(50)]
        [MinLength(2, ErrorMessage = "Le {0} doit avoir au moins {1} charactères")]
        public string Nom { get; set; }

        // Une matière peut avoir plusieurs évaluations
        public virtual ICollection<Evaluation> Evaluations { get; set; }

    }
}
