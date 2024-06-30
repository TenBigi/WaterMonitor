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
            _context = context;
        }
        
        public void OnGet()
        {
            Measurements = _context.Measurements.Include(x => x.Station).ToList();
        }
    }
}
