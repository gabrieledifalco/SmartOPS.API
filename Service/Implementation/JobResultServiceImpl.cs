using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class JobResultServiceImpl : IJobResultService
    {
        private readonly IJobResultRepository _jobResultRepository;

        public JobResultServiceImpl(IJobResultRepository jobResultRepository)
        {
            _jobResultRepository = jobResultRepository;
        }

        public async Task AddJobResultAsync(JobResult jobResult)
        {
            await _jobResultRepository.AddAsync(jobResult);
        }

        public async Task<IEnumerable<JobResult>> GetJobResultsByJobIdAsync(int jobId)
        {
            return await _jobResultRepository.GetByJobIdAsync(jobId);
        }
    }
}
