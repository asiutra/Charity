using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModel
{
    public class AddInstitutionViewModel
    {
        [Required(ErrorMessage = "Wymagana jest nazwa instytucji")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
