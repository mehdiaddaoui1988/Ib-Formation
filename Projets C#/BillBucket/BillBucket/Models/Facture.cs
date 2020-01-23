using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Facture
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name ="Numéro de Facture")]
        public int NumeroFacture { get; set; }


        private DateTime _DateEmission;

        [Required]
        [Display(Name = "Date d'émission")]
        public DateTime DateEmission
        {
            get { return _DateEmission; }
            set { _DateEmission = value.Date; }
        }


        private DateTime _DateReglement;
        [Display(Name = "Date de règlement")]
        public DateTime DateReglement
        {
            get { return _DateReglement; }
            set
            {
                if (DateEmission > value)
                {
                    throw new InvalidOperationException("La date d'émission doit précéder la date de paiement");
                }
                    _DateReglement = value.Date;
            }
        }

        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        public Guid IdClient { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Prestation> Prestations { get; set; }

    }
}
