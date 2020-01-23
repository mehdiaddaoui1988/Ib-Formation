using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Facturation.Models
{
    public class Prestation
    {
        static IEnumerable<Decimal> TauxLegauxTVA = new Decimal[] { 0.5M, 0.10M, 0.14M, 0.2M };
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; }

        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal MontantHT { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##%}")]
        public decimal TauxTVA { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MontantTVA
        {
            get
            {
                return MontantHT * TauxTVA;
            }
        }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MontantTTC
        {
            get
            {
                return MontantHT +MontantTVA;
            }
        }
        public string Remarque { get; set; }

        public Guid IdFacture { get; set; }

        public virtual Facture Facture { get; set; }

        public bool IsValidated
        {
            get
            {
                if (this.Facture == null) return true;
                return this.Facture.IsValidated;
            }
        }
    }
}