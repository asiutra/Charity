using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class DonationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            return View();
        }

    }
}