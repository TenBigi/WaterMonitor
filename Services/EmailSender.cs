using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;
using WaterMonitor.Pages.Shared;

namespace WaterMonitor.Services
{
    public class EmailSender : IEmailSender
    {
        public ApplicationDbContext _context { get; set;}
        public ILogger<EmailSender> _log { get; set; }

        public EmailSender(ILogger<EmailSender> log, ApplicationDbContext context) 
        {
            _log = log;
            _context = context;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var smtpSettings = _context.SmtpConfigs.FirstOrDefault();
            if (smtpSettings == null)
            {
                _log.LogError("SMTP settings are not configured.");
                return;
            }

            foreach (var recipient in to.Split(';'))
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(smtpSettings.FromAddress);
                    mail.To.Add(recipient);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtp = new SmtpClient(smtpSettings.Server, smtpSettings.Port))
                        {
                            smtp.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(mail);
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.LogError(ex.Message, ex);
                    }
                }
            }
        }
    }
}
