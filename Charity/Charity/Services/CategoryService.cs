using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;

namespace Charity.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CharityContext _context;

        public CategoryService(CharityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
