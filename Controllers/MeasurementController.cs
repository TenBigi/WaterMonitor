using Microsoft.AspNetCore.Mvc;
using WaterMonitor.Data.Model;
using WaterMonitor.Data;

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

        [HttpPost]
        [Route("recieve-measurements")]
        public IActionResult RecieveMeasurements(StationMeasurement mmt)
        {
            //osetreni  - duplicitni guid, chybejici stanice

            if (_context.Stations.Count() < mmt.StationId) 
            {
                mmt.StationId = _context.Stations.Count();
            }

            mmt.TimeStamp = DateTime.Now;
            _context.Measurements.Add(mmt);
            _context.SaveChanges();

            return StatusCode(200, "Added measurement: " + mmt.Id);
        }
    }
}
