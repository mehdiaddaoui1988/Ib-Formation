using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetVacances.DAL
{
    public enum EnumEtatAtterrissage
    {
        Aucun = 0, Prévu = 1, Echec = 2, Reussite = 3, Indetermine = 4
    }
    [Table("TBL_Lancements")]
    public class Lancement_DAO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTime DateLancement { get; set; }

        public string ChargeUtile { get; set; }

        [Range(0, double.MaxValue)]
        public double PoidsChargeUtile { get; set; }

        public string EtatAtterrissage { get; set; }

        public string DescriptionMission { get; set; }

        public virtual Fusee_DAO Fusee { get; set; }
        [ForeignKey("Fusee")]
        public Guid IdFusee { get; set; }
    }
}