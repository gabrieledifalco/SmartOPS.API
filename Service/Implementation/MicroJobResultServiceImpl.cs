using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class MicroJobResultServiceImpl : IMicroJobResultService
    {
        private readonly IMicroJobResultRepository _microJobResultRepository;

        public MicroJobResultServiceImpl(IMicroJobResultRepository microJobResultRepository)
        {
            _microJobResultRepository = microJobResultRepository;
        }

        public async Task AddMicroJobResultAsync(MicroJobResult microJobResult)
        {
            await _microJobResultRepository.AddAsync(microJobResult);
        }

        public async Task<IEnumerable<MicroJobResult>> GetMicroJobResultsByMicroJobIdAsync(int microJobId)
        {
            return await _microJobResultRepository.GetByMicroJobIdAsync(microJobId);
        }
    }
}
