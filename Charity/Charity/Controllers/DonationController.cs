using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Charity.Models.Form;
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
            var categoryList = await _categoryService.GetAllAsync();
            var CategoryCheckBox = new List<CheckBoxModel>();

            foreach (var category in categoryList)
            {
                CategoryCheckBox.Add(new CheckBoxModel
                {
                    id = category.Id,
                    Text = category.Name,
                });
            }


            var institutionList = await _institutionService.GetAllAsync();
            var institutionRb = new List<RadioButtonModel>();

            foreach (var institution in institutionList)
            {
                institutionRb.Add(new RadioButtonModel
                {
                    Id = institution.Id,
                    Description = institution.Description,
                    Name = institution.Name
                });
            }

            var viewModel = new DonationViewModel()
            {
                CheckBoxItems = CategoryCheckBox,
                Institutions = institutionRb,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Donate(DonationViewModel viewModel)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (!ModelState.IsValid)
                return View(viewModel);


            var categories = viewModel.CheckBoxItems.Where(x => x.IsChecked).ToList();
            var categoriesList = new List<DonationCategory>();

            foreach (var category in categories)
            {
                categoriesList.Add(new DonationCategory {CategoryId = category.id, DonationId = viewModel.Id});
            }

            //Handle for registered and logged user
            //var user = _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Błąd w tworzenia darowizny");
            //    return View(viewModel);
            //}


            var donation = new Donation()
            {
                PhoneNumber = viewModel.PhoneNumber,
                City = viewModel.City,
                Street = viewModel.Street,
                ZipCode = viewModel.ZipCode,
                Quantity = viewModel.Quantity,
                PickUpDate = viewModel.PickUpDate,
                PickUpTime = viewModel.PickUpTime,
                PickUpComment = viewModel.PickUpComment,
                Categories = categoriesList,
                Institution = await _institutionService.GetAsync(viewModel.Institution.Id),
            };

            var result = await _donationService.CreateAsync(donation);

            if (result == false)
            {
                ModelState.AddModelError("", "Błąd w tworzenia darowizny");
                return View(viewModel);
            }


            return RedirectToAction("Confirmation");
        }

        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

    }
}