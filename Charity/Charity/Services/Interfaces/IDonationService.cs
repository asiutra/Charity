using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Microsoft.AspNetCore.Identity;

namespace Charity.Services.Interfaces
{
    public interface IDonationService
    {
        Task<bool> CreateAsync(Donation donation);
        Task<Donation> GetAsync(int id);
        Task<IList<Donation>> GetAllAsync();
        Task<bool> UpdateAsync(Donation donation);
        Task<bool> DeleteAsync(int id);
        Task<int> CountInstitution();
        Task<int> SumOfAllQuantity();
        Task<IList<DonationCategory>> DonationCategory();
        Task<int> DonationId(IdentityUser userPrincipal);
    }
}
