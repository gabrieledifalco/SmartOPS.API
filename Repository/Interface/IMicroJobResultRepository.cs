using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IMicroJobResultRepository
    {
        Task<IEnumerable<MicroJobResult>> GetByMicroJobIdAsync(int microJobId);
        Task AddAsync(MicroJobResult microJobResult);
    }
}
