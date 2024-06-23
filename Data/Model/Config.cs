using System.ComponentModel.DataAnnotations;

namespace WaterMonitor.Data.Model
{
    public class Config
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
