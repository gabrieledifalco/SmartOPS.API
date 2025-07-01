using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IJobResultRepository
    {
        Task<IEnumerable<JobResult>> GetByJobIdAsync(int jobId);
        Task AddAsync(JobResult jobResult);
    }
}
