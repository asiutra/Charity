using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Charity.Models.Db
{
    public class Donation
    {
        public int ID { get; set; }
        [Required]
        public int Quantity { get; set; } //liczba worków
        public ICollection<Category> Categories { get; set; }
        public ICollection<Institution> Institutions { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpComment { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
