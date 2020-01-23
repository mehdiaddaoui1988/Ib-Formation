using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scolarite.ValidationAttributes
{
    public class EstDivisibleParAttribute : ValidationAttribute
    {
        public int Nombre { get; set; }
        public EstDivisibleParAttribute(int nombre)
        {
            this.Nombre = nombre;
            this.ErrorMessage = "{0} doit être divisible par {1}";
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, Nombre);
        }
        public override bool IsValid(object value)
        {
            var valeur = (int)value;
            return valeur % this.Nombre == 0;
        }
    }
}
