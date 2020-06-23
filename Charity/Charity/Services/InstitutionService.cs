using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;

namespace Charity.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly CharityContext _context;

        public InstitutionService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Institution institution)
        {
            throw new NotImplementedException();
        }

        public async Task<Institution> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Institution>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Institution institution)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
