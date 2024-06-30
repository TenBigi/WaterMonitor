using Microsoft.AspNetCore.Mvc;
using WaterMonitor.Data;

namespace WaterMonitor.Controllers
{
    [ApiController]
    [Route("api")]
    public class TokenController : Controller
    {
        ApplicationDbContext _context { get; set; }
        public TokenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-latest-token")]
        public IActionResult GetLatestToken()
        {
            var token = _context.Tokens.OrderByDescending(t => t.CreatedAt).Select(t => t.Token).FirstOrDefault();
            return Ok(token);
        }
    }
}
