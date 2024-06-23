using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;
using WaterMonitor.Filters;
using WaterMonitor.Services;

namespace WaterMonitor.Controlers
{
    [ApiController]
    [Route("api")]
    public class StationsController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public StationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [TokenAuthorizationFilter]
        [HttpGet]
        [Route("stations_list")]
        public IActionResult GetListOfStations()
        {
            var stations = _context.Stations.ToList();
            return StatusCode(200, new JsonResult(stations));
            
        }

        [HttpPost]
        [Route("add_station")]
        public IActionResult AddStaionFromJson(Station jsonData) 
        {
            
            jsonData.CreatedOn = DateTime.Now;

            _context.Stations.Add(jsonData);
            _context.SaveChanges();

            return Ok("Json data added to the database.");
        }
    }
}
