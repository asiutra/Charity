using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;

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
            throw new NotImplementedException();
        }

        public async Task<Donation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Donation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Donation donation)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
