using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModel
{
    public class AddAdminViewModel
    {
        [Required(ErrorMessage = "Pole wymagane!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole wymagane!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Pole wymagane!"), EmailAddress(ErrorMessage = "Podaj poprawny adres email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole wymagane!")]
        public string Password { get; set; }
    }
}
