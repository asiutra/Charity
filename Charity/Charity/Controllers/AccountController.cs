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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);


            //quickFix for exist email
            var checkEmail = await UserManager.FindByEmailAsync(viewModel.Email);
            if (checkEmail != null)
            {
                ModelState.AddModelError("", "Podany adres emali już istnieje!");
                return View(viewModel);
            }


            // trim white spaces
            var name = viewModel.Name.Replace(" ", "");
            var surname = viewModel.Surname.Replace(" ", "");

            //var user = new IdentityUser
            //{
            //    Email = viewModel.Email,
            //    UserName = name + " " + surname
            //};

            var user = new IdentityUser(viewModel.Email)
            {
                Email = viewModel.Email,
                UserName = name + " " + surname
            };


            var result = await UserManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                var message = $"To jest Twój link do aktywacji konta, kliknij w niego:\n{confirmationLink}";
                await EmailService.SendEmailAsync(user.Email, message);


                // Create and add to role - as a default all new user assign to User role
                // TODO: Allow to manage roles by admin users
                //if (!RoleManager.RoleExistsAsync("User").Result)
                //{
                //    var ir = new IdentityRole("User");
                //    await RoleManager.CreateAsync(ir);
                //}

                //Temp solution only for ensure that all users can test this app with admin and user credentials.
                var adminList = await UserManager.GetUsersInRoleAsync("Admin");
                if (adminList.Count == 0)
                {
                    await UserManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await UserManager.AddToRoleAsync(user, "User");
                }
                //await UserManager.AddToRoleAsync(user, "User");
                //await SignInManager.SignInAsync(user, false);
                //await EmailService.SendEmailAsync(viewModel.Email);
                return RedirectToAction(nameof(SuccessRegistration));
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await UserManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return View(nameof(ConfirmEmail));


            return View("Error");
        }

        public IActionResult SuccessRegistration()
        {
            return View();
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
                {
                    return RedirectToAction("Index", "Home");
                }

                var isEmailConfirmed = await UserManager.IsEmailConfirmedAsync(user);

                if (!isEmailConfirmed) ModelState.AddModelError("", "You should first confirm your email.");
                else ModelState.AddModelError("", "Invalid Login Attempt");

                return View(viewModel);
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