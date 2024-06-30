namespace WaterMonitor.Data.Model
{
    public class StationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FloodWarningvalue { get; set; }
        public int DroughWarningValue { get; set; }
        public int UnknownStateMinTime { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastMeasurementValue { get; set; }
    }
}
