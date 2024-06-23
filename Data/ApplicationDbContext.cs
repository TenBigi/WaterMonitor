using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationMeasurement> Measurements { get; set; }
        public DbSet<Config> Configuration {  get; set; }
    }
}
