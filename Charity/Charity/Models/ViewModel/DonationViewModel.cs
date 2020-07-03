using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Models.ViewModel
{
    public class DonationViewModel
    {
        public IList<Category> Categories;
        public IList<SelectListItem> CategoryItems { get; set; }
        public IList<Institution> Institutions;
        public int QuantityBag { get; set; }
        public string Institution { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpComment { get; set; }
    }
}
