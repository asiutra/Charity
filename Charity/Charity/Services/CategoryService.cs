using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.Db;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            _context.Category.Add(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Category.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }


        public async Task<bool> UpdateAsync(Category category)
        {
            _context.Category.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = _context.Category.SingleOrDefault(x => x.Id == id);
            if (category == null) return false;

            _context.Category.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
