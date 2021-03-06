﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Charity.Services
{
    public class DonationService : IDonationService
    {
        private readonly CharityContext _context;

        public DonationService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Donation donation)
        {
            _context.Add(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Donation> GetAsync(int id)
        {
            return await _context.Donation.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Donation>> GetAllAsync()
        {
            return await _context.Donation.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Donation donation)
        {
            _context.Donation.Update(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var donation = _context.Donation.SingleOrDefault(x => x.Id == id);
            if (donation == null) return false;

            _context.Donation.Remove(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CountInstitution()
        {
            return await _context.Institution.Distinct().CountAsync();
        }

        public async Task<int> SumOfAllQuantity()
        {
            return await _context.Donation.SumAsync(x => x.Quantity);
        }

        public async Task<IList<DonationCategory>> DonationCategory()
        {
            return await _context.DonationCategory.ToListAsync();
        }

        public async Task<int> DonationId(IdentityUser userPrincipal)
        {
            //return await _context.Donation.SingleOrDefaultAsync(x => x.User == userPrincipal);
            return await _context.Donation.Where(x => x.User == userPrincipal).Select(x => x.Id).SingleOrDefaultAsync();
        }
    }
}
