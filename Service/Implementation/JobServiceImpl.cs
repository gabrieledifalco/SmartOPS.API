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
    }
}
