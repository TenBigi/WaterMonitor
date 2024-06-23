using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Pages
{
    public class ConfigurationModel : GenericPageModel
    {
        public ConfigurationModel(ApplicationDbContext context) 
        {
            ApplicationDbContext = context;
        }

        public List<Config> Configs { get; set; } = [];
        public void OnGet()
        {
			Configs = ApplicationDbContext.Configuration.ToList();
		}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            return Page();

        }
    }
}
