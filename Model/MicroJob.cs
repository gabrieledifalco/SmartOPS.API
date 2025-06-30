using SmartOPS.API.Model.Enum;

namespace SmartOPS.API.Model
{
    public class MicroJob
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExecutionResult Status { get; set; }

        public DateTime? ExecutedAt { get; set; }
        public TimeSpan? Duration { get; set; }
        public string OutputData { get; set; }
        public string? ErrorMessage { get; set; }

        public Job Job { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
