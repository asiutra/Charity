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
        //public IList<Institution> Institutions { get; set; }

        //public int Quantity { get; set; }
        //public string Institution { get; set; }
        ////public int Institution { get; set; }
        ////public string Street { get; set; }
        //public string City { get; set; }
        //public string ZipCode { get; set; }
        //public string PhoneNumber { get; set; }
        //public DateTime PickUpDate { get; set; }
        //public DateTime PickUpTime { get; set; }
        //public string PickUpComment { get; set; }
    }
}
