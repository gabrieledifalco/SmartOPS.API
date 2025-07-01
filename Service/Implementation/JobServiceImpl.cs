using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class JobServiceImpl : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobServiceImpl(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task CreateJobAsync(Job job)
        {
            await _jobRepository.AddAsync(job);
        }

        public async Task DeleteJobAsync(int jobId, int companyId)
        {
            await _jobRepository.DeleteAsync(jobId, companyId);
        }

        public async Task<Job> GetJobByIdAsync(int jobId, int companyId)
        {
            return await _jobRepository.GetByIdAsync(jobId, companyId);
        }

        public Task<IEnumerable<Job>> GetJobsByCompanyAsync(int companyId)
        {
            return _jobRepository.GetAllByCompanyAsync(companyId);
        }

        public async Task UpdateJobAsync(Job job)
        {
            await _jobRepository.UpdateAsync(job);
        }
    }
}
