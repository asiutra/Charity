using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Controllers
{
    public class DonationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IInstitutionService _institutionService;

        public DonationController(ICategoryService categoryService, IInstitutionService institutionService)
        {
            this._categoryService = categoryService;
            this._institutionService = institutionService;
        }

        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            var ViewModel = new DonationViewModel();

            ViewModel.CategoryItems = new List<SelectListItem>()
            {
                new SelectListItem{Value = _categoryService.GetAsync(1).Result.ID.ToString(), Text = _categoryService.GetAsync(1).Result.Name},
                new SelectListItem{Value = _categoryService.GetAsync(2).Result.ID.ToString(), Text = _categoryService.GetAsync(2).Result.Name},
                new SelectListItem{Value = _categoryService.GetAsync(3).Result.ID.ToString(), Text = _categoryService.GetAsync(3).Result.Name},
                new SelectListItem{Value = _categoryService.GetAsync(4).Result.ID.ToString(), Text = _categoryService.GetAsync(4).Result.Name},
                new SelectListItem{Value = _categoryService.GetAsync(5).Result.ID.ToString(), Text = _categoryService.GetAsync(5).Result.Name}
            };

            ViewModel.Institutions = await _institutionService.GetAllAsync();
            
            
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Donate(DonationViewModel viewModel)
        {
            return Content("SomeValue");
            return RedirectToAction("", ""); //redirect to view of confirmation with collected data;
        }

    }
}