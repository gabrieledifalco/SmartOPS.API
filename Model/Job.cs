namespace SmartOPS.API.Model
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Scheduled, Running, Completed, Failed
        public string ScheduleType { get; set; } // Manual, Daily, Weekly
        public string CronExpression { get; set; }

        public DateTime? LastRunAt { get; set; }
        public DateTime? NextRunAt { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<JobResult> Results { get; set; }
    }
}
