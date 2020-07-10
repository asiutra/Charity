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
    public class InstitutionService : IInstitutionService
    {
        private readonly CharityContext _context;

        public InstitutionService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Institution institution)
        {
            _context.Institution.Add(institution);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Institution> GetAsync(int id)
        {
            return await _context.Institution.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetAsyncId(string name)
        {
            int id = await _context.Institution.Where(n => n.Name == name).Select(n => n.Id).SingleOrDefaultAsync();
            return id;
        }

        public async Task<Institution> GetAsyncByName(string name)
        {
            return await _context.Institution.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IList<Institution>> GetAllAsync()
        {
            return await _context.Institution.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Institution institution)
        {
            _context.Institution.Update(institution);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var institution = _context.Institution.SingleOrDefault(x => x.Id == id);
            if (institution == null) return false;

            _context.Institution.Remove(institution);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
