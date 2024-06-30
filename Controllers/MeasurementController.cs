using Microsoft.AspNetCore.Mvc;
using WaterMonitor.Data.Model;
using WaterMonitor.Data;
using WaterMonitor.Filters;

namespace WaterMonitor.Controllers
{
    [ApiController]
    [Route("api")]
    public class MeasurementController : Controller
    {
        ApplicationDbContext _context { get; set; }

        public MeasurementController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [TokenAuthorizationFilter]
        [HttpPost]
        [Route("recieve-measurements")]
        public IActionResult RecieveMeasurements(StationMeasurement mmt)
        {
            Station station = _context.Stations.FirstOrDefault(s => s.Id == mmt.StationId);
            if (station == null)
            {
                return StatusCode(400, "Station not found");
            }

            _context.Stations.Where(s => s.Id == mmt.StationId).FirstOrDefault().LastMeasurementRecievedTime = DateTime.Now;

            _context.Measurements.Add(mmt);
            _context.SaveChanges();

            return StatusCode(200, "Added measurement: " + mmt.Id);
        }
    }
}
