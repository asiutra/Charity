using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;

namespace Charity.Services.Interfaces
{
    interface IDonationService
    {
        Task<bool> CreateAsync(Donation donation);
        Task<Donation> GetAsync(int id);
        Task<IList<Donation>> GetAllAsync();
        Task<bool> UpdateAsync(Donation donation);
        Task<bool> DeleteAsync(int id);
    }
}
