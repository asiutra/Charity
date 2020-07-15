using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Charity.Services
{
    public class AdminService : IAdminService
    {
        private readonly CharityContext _context;

        public AdminService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> LockUserAsync(string id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.MaxValue;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UnlockUserAsync(string id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
