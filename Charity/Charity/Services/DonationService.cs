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
    public class DonationService : IDonationService
    {
        private readonly CharityContext _context;

        public DonationService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Donation donation)
        {
            _context.Donation.Add(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Donation> GetAsync(int id)
        {
            return await _context.Donation.SingleOrDefaultAsync(x => x.ID == id);
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
            var donation = _context.Donation.SingleOrDefault(x => x.ID == id);
            if (donation == null) return false;

            _context.Donation.Remove(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CountInstitution()
        {
            return await _context.Donation.Select(x => x.Institutions).Distinct().CountAsync();
        }

        public async Task<int> SumOfAllQuantity()
        {
            return await _context.Donation.Select(x => x.Quantity).SumAsync();
        }
    }
}
