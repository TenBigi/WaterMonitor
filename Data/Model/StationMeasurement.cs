using System.ComponentModel.DataAnnotations;

namespace WaterMonitor.Data.Model
{
    public class StationMeasurement
    {
        [Key]
        public Guid Id { get; set; }
        public int StationId { get; set; }
        public virtual Station? Station { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Value { get; set; }
    }
}
