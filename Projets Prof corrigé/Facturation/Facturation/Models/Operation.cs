using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Operation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]

        public Guid IdClient { get; set; }
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Montant { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteData { get; set; }
    }
}
