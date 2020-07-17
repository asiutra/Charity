using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Charity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }
        protected IAdminService AdminService;
        protected IInstitutionService InstitutionService;

        public AdminController(UserManager<IdentityUser> userManager, IAdminService adminService, IInstitutionService institutionService)
        {
            UserManager = userManager;
            AdminService = adminService;
            InstitutionService = institutionService;
        }


        public async Task<IActionResult> ShowUsers()
        {
            var users = await UserManager.GetUsersInRoleAsync("User");
            return View(users);
        }

        public async Task<IActionResult> Lock(string id)
        {
            await AdminService.LockUserAsync(id);
            return RedirectToAction("ShowUsers");
        }

        public async Task<IActionResult> Unlock(string id)
        {
            await AdminService.UnlockUserAsync(id);
            return RedirectToAction("ShowUsers");
        }

        public async Task<IActionResult> ShowInstitution()
        {
            var institution = await InstitutionService.GetAllAsync();
            return View(institution);
        }

        [HttpGet]
        public async Task<IActionResult> EditInstitution(int id)
        {
            var institutionToEdit = await InstitutionService.GetAsync(id);
            var viewModel = new EditInstitutionViewModel()
            {
                Id = institutionToEdit.Id,
                Name = institutionToEdit.Name,
                Description = institutionToEdit.Description
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstitution(EditInstitutionViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var institution = new Institution()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            var result = await InstitutionService.UpdateAsync(institution);
            if (result == false)
            {
                ModelState.AddModelError("", "Błąd edycji instytucji");
                return View(viewModel);
            }

            return RedirectToAction("ShowInstitution", "Admin");
        }

        [HttpGet]
        public IActionResult AddInstitution()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstitution(AddInstitutionViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var institution = new Institution()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            var result = await InstitutionService.CreateAsync(institution);

            if (result == false)
            {
                ModelState.AddModelError("", "Nie można dodać nowej instytucji");
                return View(viewModel);
            }

            return RedirectToAction("ShowInstitution", "Admin");
        }

        public async Task<IActionResult> RemoveInstitution(int id)
        {
            await InstitutionService.DeleteAsync(id);
            return RedirectToAction("ShowInstitution", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAdmins()
        {
            var adminList = await UserManager.GetUsersInRoleAsync("Admin");
            return View(adminList);
        }

        [HttpGet]
        public async Task<IActionResult> AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var fullName = $"{viewModel.Name} {viewModel.Surname}";

            var admin = new IdentityUser()
            {
                UserName = fullName,
                Email = viewModel.Email
            };

            var result = await UserManager.CreateAsync(admin, viewModel.Password);

            if (!result.Succeeded) return View(viewModel);

            await UserManager.AddToRoleAsync(admin, "Admin");
            return RedirectToAction("ShowAdmins", "Admin");

        }

    }
}