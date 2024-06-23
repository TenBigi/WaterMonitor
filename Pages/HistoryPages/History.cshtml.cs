using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Pages.HistoryPages
{
    [Authorize]
    public class HistoryModel : GenericPageModel
    {
        public List<StationMeasurement> Measurements { get; set; } = [];
        public HistoryModel(ApplicationDbContext context)
        {
            ApplicationDbContext = context;
        }
        
        public void OnGet()
        {
            Measurements = ApplicationDbContext.Measurements.Include(x => x.Station).ToList();
        }
    }
}
