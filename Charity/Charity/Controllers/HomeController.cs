using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models;
using Charity.Models.Db;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IInstitutionService institutionService, [FromServices] IDonationService donationService, [FromServices] ICategoryService categoryService)
        {
            var viewModel = new IndexViewModel()
            {
                InstitutionList = await institutionService.GetAllAsync(),
                CountSupportedCharities = await donationService.CountInstitution(),
                SumOfQuantity = await donationService.SumOfAllQuantity(),
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}