using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterMonitor.Data.Model;
using WaterMonitor.Data;

namespace WaterMonitor.Pages.StationPages
{
    public class HomeModel : GenericPageModel
    {
        public List<Station> Stations { get; set; } = [];
        public List<StationMeasurement> StationMeasurements { get; set; } = [];

        public HomeModel(ApplicationDbContext context)
        {
            ApplicationDbContext = context;
        }   
        public void OnGet()
        {
            Stations = [.. ApplicationDbContext.Stations];
            StationMeasurements = ApplicationDbContext.Measurements.ToList();
        }
    }
}
