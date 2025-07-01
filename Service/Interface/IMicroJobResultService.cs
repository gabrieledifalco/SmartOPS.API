using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IMicroJobResultService
    {
        Task<IEnumerable<MicroJobResult>> GetMicroJobResultsByMicroJobIdAsync(int microJobId);
        Task AddMicroJobResultAsync(MicroJobResult microJobResult);
    }
}
