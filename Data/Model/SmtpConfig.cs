using System.ComponentModel.DataAnnotations;

namespace WaterMonitor.Data.Model
{
    public class SmtpConfig
    {
        [Key]
        public int Id { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
    }
}
