using SmartOPS.API.Model;

namespace SmartOPS.API.DTO.Response
{
    public class JobResultDTO
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public string Result { get; set; }
        public string OutputData { get; set; }
        public string? ErrorMessage { get; set; }

        public JobDTO Job { get; set; }
    }
}
