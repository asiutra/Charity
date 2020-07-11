using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    //Controller available only for Admin
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}