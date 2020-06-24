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
        private readonly IDonationService _donationService;

        public HomeController(IInstitutionService institutionService, IDonationService donationService)
        {
            _institutionService = institutionService;
            _donationService = donationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var count = await _donationService.GetAllAsync();
            ViewBag.Quantity = count;

            var institutions = await _institutionService.GetAllAsync();
            return View(institutions);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}