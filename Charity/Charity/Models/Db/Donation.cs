using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Charity.Models.Db
{
    public class Donation
    {
        public int Id { get; set; }
        public int Quantity { get; set; } 
        public IList<DonationCategory> Categories { get; set; }
        public Institution Institution { get; set; }

        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpComment { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
