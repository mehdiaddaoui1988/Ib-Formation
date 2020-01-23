using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstApp.Models
{
    [Table("Tbl_Reponses")]
    public class Reponse
    {


        
        [Column("Fk_Question")]
        public Guid IdQuestion { get; set; }

        [Column("Fk_Utilisateur")]
        public Guid IdUtilisateur { get; set; }
        public bool Valeur { get; set; }


        [DataType("DATETIME2")]
        public DateTime DateReponse { get; set; } = DateTime.Now;

      
 
        public virtual Question Question { get; set; }

        [ForeignKey("IdUtilisateur")]
        public virtual Utilisateur Utilisateur { get; set; }
    }
}