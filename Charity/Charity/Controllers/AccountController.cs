using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }
        protected SignInManager<IdentityUser> SignInManager { get; }
        protected RoleManager<IdentityRole> RoleManager { get; }
        protected IEmailService EmailService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            EmailService = emailService;
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
            var surname = viewModel.Surname.Replace(" ", "");

            var user = new IdentityUser
            {
                Email = viewModel.Email,
                UserName = name + " " + surname
            };

            var result = await UserManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                // Create and add to role - as a default all new user assign to User role
                // TODO: Allow to manage roles by admin users
                if (!RoleManager.RoleExistsAsync("User").Result)
                {
                    var ir = new IdentityRole("User");
                    await RoleManager.CreateAsync(ir);
                }

                await UserManager.AddToRoleAsync(user, "User");
                await SignInManager.SignInAsync(user, false);
                await EmailService.SendEmailAsync(viewModel.Email); 
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