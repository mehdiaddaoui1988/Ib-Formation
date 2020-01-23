using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroazApi.Models
{
    public class Groaz
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        [Range(1, 10)]
        public int NiveauDeBins { get; set; } = 1;

        [Required]
        public string Trut { get; set; }
      
        public DateTime DateNaissance { get; set; } = DateTime.Now;

        public Guid? IdParain { get; set; }
        public virtual Groaz Parain { get; set; }

        public ICollection<Groaz> FilleulSet { get; set; }

        public string Grun(string chnuk)
        {
            return "";
        }
    }
}
