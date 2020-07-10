using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;

namespace Charity.Models.Form
{
    public class RadioButtonModel : Institution
    {
        public bool IsChecked { get; set; }
    }
}
