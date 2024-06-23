using System.ComponentModel.DataAnnotations;

namespace WaterMonitor.Data.Model
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        public int FloodWarningvalue { get; set; }
        public int DroughWarningValue { get; set; }
        public string? CreatedByUser { get; set; }
        public DateTime CreatedOn { get; set; }    
    }
}
