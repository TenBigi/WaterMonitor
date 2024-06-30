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
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //osetreni - max level > min level
            Station.CreatedOn = DateTime.Now;
            _context.Stations.Add(Station);
            _context.SaveChanges();
            Station = new();
            ModelState.Clear();
            return Page();
        }
    }
}
