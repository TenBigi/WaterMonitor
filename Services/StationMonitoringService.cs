using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WaterMonitor.Data;
using WaterMonitor.Services;

namespace WaterMonitor.Services
{
    public class StationMonitoringService
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailSender _emailSender;

        public StationMonitoringService(ApplicationDbContext context, EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public void CheckStations()
        {
            try
            {
                var stations = _context.Stations;
                foreach (var station in stations)
                {
                    var timeElapsed = DateTime.UtcNow - station.LastMeasurementRecievedTime;
                    var minTimeThreshold = TimeSpan.FromMinutes(station.UnknownStateMinTime);

                    if (timeElapsed > minTimeThreshold)
                    {
                        var subject = $"Station {station.Title} exceeded maximum time without data.";
                        var body = $"Station {station.Title} has not sent data for {timeElapsed} minutes.";
                        _emailSender.SendEmailAsync("jeniksoffer@gmail.com", subject, body).GetAwaiter().GetResult();
                        Console.WriteLine("Email sent");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
