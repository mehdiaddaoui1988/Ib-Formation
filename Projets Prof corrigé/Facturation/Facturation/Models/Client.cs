using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Client
    {
    
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string RaisonSociale { get; set; }

        public byte[] MotDePasse { get; set; }
        public string Remarque { get; set; }
        public string Mail { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; } = "France";
        public virtual ICollection<Facture> Factures { get; set; }
        public virtual ICollection<Paiement> Paiements { get; set; }

        [Display(Name ="Chiffre d'affaire")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal CA
        {
            get
            {
                if (Factures==null || Factures.Count() == 0) return 0;
                return Factures.Where(c=>c.DateEdition!=null).Sum(c => c.MontantHT);
            }
        }
        [Display(Name = "Paiements")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPaiements
        {
            get
            {
                if (Paiements == null || Paiements.Count() == 0) return 0;
                return Paiements.Sum(c => c.Montant);
            }
        }
        [Display(Name = "Total échéances")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalEcheances
        {
            get
            {
                if (Factures == null || Factures.Count() == 0) return 0;
                return Factures.Where(c => c.DateEcheance != null && c.DateEcheance < DateTime.Now).Sum(c => c.MontantTTC);
            }
        }
        [Display(Name = "Total du")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalDu
        {
            get
            {
                if (Factures == null || Factures.Count() == 0) return 0;
                return Factures.Sum(c => c.MontantTTC);
            }
        }
        [Display(Name = "Retard")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Retard
        {
            get
            {
                return TotalEcheances - TotalPaiements;
            }
        }
        [Display(Name = "Solde")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Solde
        {
            get
            {
                return TotalPaiements - TotalDu;
            }
        }

    }
}
