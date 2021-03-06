﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(Category category);
        Task<Category> GetAsync(int id);
        Task<IList<Category>> GetAllAsync();
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}
