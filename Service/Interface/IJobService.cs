using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IJobService
    {
        Task<Job> GetJobByIdAsync(int jobId, int companyId);
        Task<IEnumerable<Job>> GetJobsByCompanyAsync(int companyId);
        Task CreateJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int jobId, int companyId);
    }
}
