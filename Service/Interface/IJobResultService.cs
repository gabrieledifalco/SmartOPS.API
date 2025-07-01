using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IJobResultService
    {
        Task<IEnumerable<JobResult>> GetJobResultsByJobIdAsync(int jobId);
        Task AddJobResultAsync(JobResult jobResult);
    }
}
