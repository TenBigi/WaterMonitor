using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using WaterMonitor.Pages.Shared;

namespace WaterMonitor.Services
{
    public class EmailSender : IEmailSender
    {
        public ILogger<EmailSender> _log { get; set; }

        public EmailSender(ILogger<EmailSender> log) 
        {
            _log = log;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            foreach (var recipient in to.Split(';'))
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("jeniksoffer@gmail.com");
                    mail.To.Add(recipient);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtp = new SmtpClient("smtp.forpsi.cz", 587))
                        {
                            smtp.Credentials = new NetworkCredential("noreply@codeclimber.cz", "Alia2022+");
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
