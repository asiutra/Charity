using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Charity.Services.Interfaces;

namespace Charity.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string mailTo)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("charit1.projekt@gmail.com", "StrongPass1!")
            };

            using (var message = new MailMessage("charit1.projekt@gmail.com", mailTo)
            {
                Subject = $"Witamy na pokładzie - {mailTo}",
                Body = "Dziękujemy za rejstrację, życzymy miłego dnia!\n\nPozdrawiamy,\nZespół CharityProjekt"
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }

        public async Task SendEmailAsync(string mailTo, string content)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("charit1.projekt@gmail.com", "StrongPass1!")
            };

            if (content is null)
            {
                using (var message = new MailMessage("charit1.projekt@gmail.com", mailTo)
                {
                    Subject = $"Witamy na pokładzie - {mailTo}",
                    Body = "Dziękujemy za rejstrację, życzymy miłego dnia!\n\nPozdrawiamy,\nZespół CharityProjekt"
                })
                {
                    await smtpClient.SendMailAsync(message);
                }
            }
            else
            {
                using (var message = new MailMessage("charit1.projekt@gmail.com", mailTo)
            {
                Subject = $"Witamy na pokładzie - {mailTo}",
                Body = content
            })
            {
                await smtpClient.SendMailAsync(message);
            }
            }
        }
    }
}
