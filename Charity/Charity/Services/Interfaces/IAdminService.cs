using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;

namespace Charity.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> LockUserAsync(string id);
        Task<bool> UnlockUserAsync(string id);
    }
}
