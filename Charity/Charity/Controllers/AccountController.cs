using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }
        protected SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // trim white spaces
            var name = viewModel.Name.Replace(" ", "");
            var surname = viewModel.Surname.Replace(" ","");

            var user = new IdentityUser
            {
                Email = viewModel.Email,
                UserName = name + " " + surname
            };

            var result = await UserManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(viewModel.Email);
                var result = await SignInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Błąd logowania");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}