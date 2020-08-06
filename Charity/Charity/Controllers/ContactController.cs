using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.ViewModel;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class ContactController : Controller
    {
        protected IEmailService EmailService;

        public ContactController(IEmailService emailService)
        {
            EmailService = emailService;
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(SendEmailViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var fullName = $"{viewModel.Name} {viewModel.Surname}";
            var email = viewModel.Email;
            var message = viewModel.Message;

            var mailTo = "charit1.projekt@gmail.com";
            var content = $"Wiadomość wysłana przez: {fullName}, emali: {email}\ntreść:\n\n{message}";

            await EmailService.SendEmailAsync(mailTo, "Nowa wiadomość od klienta", content);

            return RedirectToAction("Confirmation", "Contact");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}