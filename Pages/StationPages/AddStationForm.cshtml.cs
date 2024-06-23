using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Pages.StationPages
{
    
    public class AddStationFormModel : GenericPageModel
    {
        [BindProperty]
        public Station Station { get; set; } = new();

        public AddStationFormModel(ApplicationDbContext context)
        {
            ApplicationDbContext = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //osetreni - max level > min level
            Station.CreatedOn = DateTime.Now;
            ApplicationDbContext.Stations.Add(Station);
            ApplicationDbContext.SaveChanges();
            Station = new();
            ModelState.Clear();
            return Page();
        }

        public void OnGet()
        {
        }
    }
}
