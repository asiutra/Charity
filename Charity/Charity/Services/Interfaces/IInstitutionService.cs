using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;

namespace Charity.Services.Interfaces
{
    public interface IInstitutionService
    {
        Task<bool> CreateAsync(Institution institution);
        Task<Institution> GetAsync(int id);
        Task<int> GetAsyncId(string name);
        Task<Institution> GetAsyncByName(string name);
        Task<IList<Institution>> GetAllAsync();
        Task<bool> UpdateAsync(Institution institution);
        Task<bool> DeleteAsync(int id);
    }
}
