using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IMicroJobRepository
    {
        Task<MicroJob> GetByIdAsync(int microJobId, int companyId);
        Task<IEnumerable<MicroJob>> GetByJobIdAsync(int jobId, int companyId);
        Task AddAsync(MicroJob microJob);
        Task UpdateAsync(MicroJob microJob);
        Task DeleteAsync(int microJobId, int companyId);
    }
}
