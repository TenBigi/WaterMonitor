using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace WaterMonitor.Pages.StationPages
{
    [Authorize]
    public class StationHomeModel : GenericPageModel
    {
        public StationHomeModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<StationViewModel> Stations { get; set; } = [];
        public List<StationMeasurement> SelectedStationMeasurements { get; set; } = new List<StationMeasurement>();
        [BindProperty]
        public int? SelectedStationId { get; set; }

        [BindProperty]
        public StationViewModel SelectedStation { get; set; }


        public void OnGet(int? id)
        {
            var stations = _context.Stations.ToList();

            foreach (var station in stations)
            {
                var lastMeasurement = _context.Measurements
                    .Where(m => m.StationId == station.Id)
                    .OrderByDescending(m => m.TimeStamp)
                    .FirstOrDefault();

                var viewModel = new StationViewModel
                {
                    Id = station.Id,
                    Title = station.Title,
                    FloodWarningvalue = station.FloodWarningvalue,
                    DroughWarningValue = station.DroughWarningValue,
                    CreatedByUser = station.CreatedByUser,
                    CreatedOn = station.CreatedOn,
                    LastMeasurementValue = lastMeasurement != null ? lastMeasurement.Value : 0
                };
                Stations.Add(viewModel);
            }

            if (id != null)
            {
                SelectedStationId = id;
                SelectedStationMeasurements = _context.Measurements
                    .Where(m => m.StationId == id).OrderByDescending(m => m.TimeStamp).ToList();
            }
        }
        public IActionResult OnPostSaveSettings()
        {
            ModelState.Remove("SelectedStation.Title");
            ModelState.Remove("SelectedStation.CreatedByUser");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            Station? station = _context.Stations.FirstOrDefault(s => s.Id == SelectedStationId);
            if (station == null)
            {
                Console.WriteLine(SelectedStation.Id);
                Console.WriteLine("Station not found");
            }
            if (station != null)
            {
                Console.WriteLine("Updating station");
                station.FloodWarningvalue = SelectedStation.FloodWarningvalue;
                station.DroughWarningValue = SelectedStation.DroughWarningValue;
                station.UnknownStateMinTime = SelectedStation.UnknownStateMinTime;
                _context.SaveChanges();
            }

            return RedirectToPage(new { id = SelectedStationId });
        }

        [HttpPost]
        public IActionResult OnPostRemoveStation(int id)
        {
            var stationToRemove = _context.Stations.FirstOrDefault(s => s.Id == id);
            if (stationToRemove != null)
            {
                _context.Stations.Remove(stationToRemove);
                _context.SaveChanges();

                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}
