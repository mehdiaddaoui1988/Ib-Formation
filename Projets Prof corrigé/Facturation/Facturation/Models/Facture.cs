using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Facture
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Reference { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime? DateEdition { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime DateEcheance { get; set; } = DateTime.Now.AddDays(30);

        [RegularExpression(@"\d{}")]
        [Display(Name = "Numéro")]
        [DisplayFormat(NullDisplayText = "-----")]
        public string Numero { get; set; }

        public string Remarque { get; set; }


        public virtual ICollection<Prestation> Prestations { get; set; }

        public Guid IdClient { get; set; }
        public virtual Client Client { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MontantTTC
        {
            get
            {
                if (this.Prestations == null) return 0m;
                return this.Prestations.Sum(c => c.MontantTTC);
            }
        }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MontantTVA
        {
            get
            {
                if (this.Prestations == null) return 0m;
                return this.Prestations.Sum(c => c.MontantTVA);
            }
        }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MontantHT
        {
            get
            {
                if (this.Prestations == null) return 0m;
                return this.Prestations.Sum(c => c.MontantHT);
            }
        }

        public bool CanCreate
        {
            get
            {
                return String.IsNullOrWhiteSpace(Numero);
            }
        }
        public bool IsValidated
        {
            get
            {
                return DateEdition != null;
            }

        }
        public bool CanValidate
        {
            get
            {
                if (IsValidated) return false;
                if (Prestations == null) return false;
                return Prestations.Count() > 0;
            }

        }
    }
}
