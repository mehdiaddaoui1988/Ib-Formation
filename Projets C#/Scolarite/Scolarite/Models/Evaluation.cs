using Scolarite.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scolarite.Models
{
    public class Evaluation
    {
 

        public Guid  IdEleve { get; set; }

        public Guid IdMatiere { get; set; }


        private DateTime _Date=DateTime.Now.Date;

        [Required]
        [Display(Name = "Date évaluation")]
        public DateTime Date
        {
            get { return _Date; }
            set { 
                // J'oublie la composante heure de la date
                _Date = value.Date;
            }
        }

        [EstDivisiblePar(2)]
        [Range(0,20)]
        [Display(Name="Note")]
        [Required]
        public int Note { get; set; }

        [Display(Name = "Appréciation")]
        [MaxLength(200)]
        [MinLength(5, ErrorMessage = "{0} doit avoir au moins {1} charactères")]
        public string Appreciation { get; set; }

        // 1 évaluation ne concerne qu'une seule matière
        public virtual Matiere Matiere { get; set; }
        // 1 évaluation ne concerne qu'un seule élève
        public virtual Eleve Eleve { get; set; }

    }
}
