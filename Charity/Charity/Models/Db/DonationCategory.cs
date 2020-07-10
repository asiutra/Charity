using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.Db
{
    public class DonationCategory
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public int CategoryId { get; set; }
    }
}
