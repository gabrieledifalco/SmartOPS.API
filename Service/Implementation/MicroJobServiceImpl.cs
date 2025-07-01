using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class MicroJobServiceImpl : IMicroJobService
    {
        private readonly IMicroJobRepository _microJobRepository;

        public MicroJobServiceImpl(IMicroJobRepository microJobRepository)
        {
            _microJobRepository = microJobRepository;
        }

        public async Task CreateMicroJobAsync(MicroJob microJob)
        {
            await _microJobRepository.AddAsync(microJob);
        }

        public async Task DeleteMicroJobAsync(int microJobId, int companyId)
        {
            await _microJobRepository.DeleteAsync(microJobId, companyId);
        }

        public async Task<MicroJob> GetMicroJobByIdAsync(int microJobId, int companyId)
        {
            return await _microJobRepository.GetByIdAsync(microJobId, companyId);
        }

        public async Task<IEnumerable<MicroJob>> GetMicroJobsByJobIdAsync(int jobId, int companyId)
        {
            return await _microJobRepository.GetByJobIdAsync(jobId, companyId);
        }

        public async Task UpdateMicroJobAsync(MicroJob microJob)
        {
            await _microJobRepository.UpdateAsync(microJob);
        }
    }
}
