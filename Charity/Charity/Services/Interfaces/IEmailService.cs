using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string mailTo);
        Task SendEmailAsync(string mailTo, string content);
    }
}
