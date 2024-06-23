using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Pages.StationPages
{
    
    public class StationHomeModel : GenericPageModel
    {
        public List<Station> Stations { get; set; } = [];
        public StationHomeModel(ApplicationDbContext context)
        {
            ApplicationDbContext = context;
        }

        public void OnGet()
        {
            Stations = [.. ApplicationDbContext.Stations];
        }
    }
}
