using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Controllers
{
    public class DonationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IInstitutionService _institutionService;
        private readonly IDonationService _donationService;
        private readonly UserManager<IdentityUser> _userManager;

        public DonationController(ICategoryService categoryService, IInstitutionService institutionService, IDonationService donationService, UserManager<IdentityUser> userManager)
        {
            this._categoryService = categoryService;
            this._institutionService = institutionService;
            this._donationService = donationService;
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            var ViewModel = new DonationViewModel();

            //ViewModel.CategoryItems = new List<SelectListItem>()
            //{
            //    new SelectListItem{Value = _categoryService.GetAsync(1).Result.ID.ToString(), Text = _categoryService.GetAsync(1).Result.Name},
            //    new SelectListItem{Value = _categoryService.GetAsync(2).Result.ID.ToString(), Text = _categoryService.GetAsync(2).Result.Name},
            //    new SelectListItem{Value = _categoryService.GetAsync(3).Result.ID.ToString(), Text = _categoryService.GetAsync(3).Result.Name},
            //    new SelectListItem{Value = _categoryService.GetAsync(4).Result.ID.ToString(), Text = _categoryService.GetAsync(4).Result.Name},
            //    new SelectListItem{Value = _categoryService.GetAsync(5).Result.ID.ToString(), Text = _categoryService.GetAsync(5).Result.Name}
            //};



            var categories = await _categoryService.GetAllAsync();
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoryItems.Add(new SelectListItem(category.Name, category.ID.ToString()));
            }

            ViewModel.CategoryItems = categoryItems;





            ViewModel.Institutions = await _institutionService.GetAllAsync();

            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Donate(DonationViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            //Handle for registered and logged user
            //var user = _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Błąd w tworzenia darowizny");
            //    return View(viewModel);
            //}

            //List<string> selectedText = null;
            //List<string> selectedValue = null;
            //foreach (var category in viewModel.CategoryItems)
            //{
            //    if (category.Selected)
            //    {
            //        selectedText.Add(category.Text);
            //        selectedValue.Add(category.Value);
            //    }
            //}

            var donation = new Donation()
            {
                Street = viewModel.Street,
                ZipCode = viewModel.ZipCode,
                Quantity = viewModel.QuantityBag,
                PickUpDate = viewModel.PickUpDate,
                PickUpTime = viewModel.PickUpTime,
                PickUpComment = viewModel.PickUpComment
            };

            //var result = await _donationService.CreateAsync(donation);

            //if (result == false)
            //{
            //    ModelState.AddModelError("", "Błąd w tworzenia darowizny");
            //    return View(viewModel);
            //}

            return RedirectToAction("Confirmation");
        }

        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

    }
}