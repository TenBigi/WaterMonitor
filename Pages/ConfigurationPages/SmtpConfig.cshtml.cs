using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Pages.ConfigurationPages
{
    [Authorize]
    public class SmtpConfigModel : GenericPageModel
    {
        [BindProperty]
        public SmtpConfig SmtpConfig { get; set; }

        public SmtpConfigModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            SmtpConfig = _context.SmtpConfigs.FirstOrDefault();
            if (SmtpConfig == null)
            {
                SmtpConfig = new SmtpConfig();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingConfig = _context.SmtpConfigs.FirstOrDefault();
            if (existingConfig != null)
            {
                existingConfig.Server = SmtpConfig.Server;
                existingConfig.Port = SmtpConfig.Port;
                existingConfig.Username = SmtpConfig.Username;
                existingConfig.Password = SmtpConfig.Password;
                existingConfig.FromAddress = SmtpConfig.FromAddress;
            }
            else
            {
                _context.SmtpConfigs.Add(SmtpConfig);
            }

            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
