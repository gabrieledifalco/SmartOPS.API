using SmartOPS.API.Model;

namespace SmartOPS.API.DTO.Response
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ScheduleType { get; set; }
        public string CronExpression { get; set; }

        public DateTime? LastRunAt { get; set; }
        public DateTime? NextRunAt { get; set; }

        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public ICollection<JobResultDTO>? Results { get; set; }
    }
}
