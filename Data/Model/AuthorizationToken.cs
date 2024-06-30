using System.ComponentModel.DataAnnotations;

namespace WaterMonitor.Data.Model
{
    public class AuthorizationToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
