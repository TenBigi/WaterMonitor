using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterMonitor.Data;

namespace WaterMonitor.Data.Model
{
    public class GenericPageModel : PageModel
    {
        internal ApplicationDbContext ApplicationDbContext;
        public string Message { get; set; } = string.Empty;
    }
}
