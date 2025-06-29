namespace SmartOPS.API.Model
{
    public class JobResult
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public string Result { get; set; } // Success, Fail
        public string OutputData { get; set; }
        public string? ErrorMessage { get; set; }

        public Job Job { get; set; }
    }
}
