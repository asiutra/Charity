using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;

namespace Charity.Models.ViewModel
{
    public class IndexViewModel
    {
        public IList<Donation> DonationList;
        public IList<Institution> InstitutionList;
        public IList<Category> CategoryList;
        public int CountSupportedCharities;
        public int SumOfQuantity;
    }
}
