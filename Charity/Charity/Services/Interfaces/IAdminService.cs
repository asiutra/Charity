using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> LockUser(string id);
        Task<bool> UnlockUser(string id);
    }
}
