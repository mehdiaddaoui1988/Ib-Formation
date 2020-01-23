using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetVacances.DAL
{
    [Table("TBL_Fusees")]
    public class Fusee_DAO
    {
        [Key]
        [Column("PK_Fusee")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Modele { get; set; }

        public int NombreDeVols { get; set; }

        public string Entreprise { get; set; }

        public virtual ICollection<Lancement_DAO> Lancements { get; set; }
    }
}