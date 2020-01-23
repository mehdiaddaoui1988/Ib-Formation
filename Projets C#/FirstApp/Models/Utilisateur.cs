using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApp.Models
{
    [Table("Tbl_Utilisateurs")]
    public class Utilisateur
    {
        [Column("Pk_Utilisateur")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required()]
        [MaxLength(50)]
        [MinLength(3,ErrorMessage ="Le {0} doit avoir au moins {1} charactères")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required()]
        [MaxLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Mail { get; set; }

        [Display(Name ="Mot de passe")]
        public Byte[] Password { get; set; }

        public virtual ICollection<Reponse> Reponses { get; set; }
    }
}