﻿using SmartOPS.API.Model.Enum;

namespace SmartOPS.API.Model
{
    public class JobResult
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public ExecutionResult Result { get; set; }
        public string OutputData { get; set; }
        public string? ErrorMessage { get; set; }

        public Job Job { get; set; }
    }
}
