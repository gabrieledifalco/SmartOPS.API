using SmartOPS.API.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartOPS.API.Model
{
    public class MicroJobResult
    {
        public int Id { get; set; }
        public int MicroJobId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public ExecutionResult Status { get; set; }
        public string OutputData { get; set; }
        public string? ErrorMessage { get; set; }

        public MicroJob MicroJob { get; set; }

        [NotMapped]
        public Job Job => MicroJob?.Job; // Helper property
    }
}
