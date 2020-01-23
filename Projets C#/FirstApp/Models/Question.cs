using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApp.Models
{
 
    public class Question
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required()]
        [MaxLength(200)]
        [MinLength(5)]
        [Display(Name="Texte")]
        public string Text { get; set; }

        public virtual ICollection<Reponse> Reponses { get; set; }
    }
}