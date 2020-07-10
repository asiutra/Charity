using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Wprowadź adres email"), EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wprowadź hasło")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Potwierdź hasło"), Compare("Password", ErrorMessage = "Wprowadzone hasła nie są takie same!")]
        public string ConfirmPassword { get; set; }
    }
}
