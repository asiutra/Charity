using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    // Controller will be for lock/unlock/show our users
    // Controller available only for Admin
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }
        protected IAdminService AdminService;

        public AdminController(UserManager<IdentityUser> userManager, IAdminService adminService)
        {
            UserManager = userManager;
            AdminService = adminService;
        }


        //[HttpGet]
        public async Task<IActionResult> ShowUsers()
        {
            var users = await UserManager.GetUsersInRoleAsync("User");
            return View(users);
        }

        public async Task<IActionResult> Lock(string id)
        {
            await AdminService.LockUser(id);
            return RedirectToAction("ShowUsers");
        }

        public async Task<IActionResult> Unlock(string id)
        {
            await AdminService.UnlockUser(id);
            return RedirectToAction("ShowUsers");
        }
    }
}