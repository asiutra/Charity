using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models;
using Charity.Models.Db;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInstitutionService _institutionService;

        public HomeController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var institutions = await _institutionService.GetAllAsync();
            return View(institutions);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}