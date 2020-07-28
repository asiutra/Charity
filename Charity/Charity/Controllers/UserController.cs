using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class UserController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }

        public UserController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var currnetUser = await UserManager.GetUserAsync(User);

            var fullUserName = currnetUser.UserName.Split(" ");
            var name = fullUserName[0];
            var surname = fullUserName[1];

            var userToEdit = new EditUserViewModel()
            {
                Name = name,
                Surname = surname,
                Email = currnetUser.Email,
            };

            return View(userToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var fullName = $"{viewModel.Name} {viewModel.Surname}";
            var currentUser = await UserManager.GetUserAsync(User);
            currentUser.UserName = fullName;
            currentUser.Email = viewModel.Email;
            currentUser.PasswordHash = UserManager.PasswordHasher.HashPassword(currentUser, viewModel.Password);

            var result = await UserManager.UpdateAsync(currentUser);

            if (result.Succeeded) return RedirectToAction("ConfirmationEdit");

            ModelState.AddModelError("", "Błąd edycji danych");
            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmationEdit()
        {
            return View();
        }
    }
}