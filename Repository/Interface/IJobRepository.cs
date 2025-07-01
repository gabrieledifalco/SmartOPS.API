using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int jobId, int companyId);
        Task<IEnumerable<Job>> GetAllByCompanyAsync(int companyId);
        Task AddAsync(Job job);
        Task UpdateAsync(Job job);
        Task DeleteAsync(int jobId, int companyId);
    }
}
