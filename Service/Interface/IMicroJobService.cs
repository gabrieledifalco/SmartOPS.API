using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IMicroJobService
    {
        Task<MicroJob> GetMicroJobByIdAsync(int microJobId, int companyId);
        Task<IEnumerable<MicroJob>> GetMicroJobsByJobIdAsync(int jobId, int companyId);
        Task CreateMicroJobAsync(MicroJob microJob);
        Task UpdateMicroJobAsync(MicroJob microJob);
        Task DeleteMicroJobAsync(int microJobId, int companyId);
    }
}
