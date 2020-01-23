using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class LoginModel
    {
      
        [Required]
        [MinLength(5)]
        public string Login { get; set; }

        [Required]
        [MinLength(5)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage ="Le mot de passe n'est pas assez complexe")]
        public string Password { get; set; }
    }
}
