using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Charity.Models.Form;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Models.ViewModel
{
    public class DonationViewModel : Donation
    {
        public IList<CheckBoxModel> CheckBoxItems { get; set; }
        public IList<RadioButtonModel> Institutions { get; set; }
    }
}
