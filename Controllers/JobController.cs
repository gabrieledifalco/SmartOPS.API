using Microsoft.AspNetCore.Mvc;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Controllers
{
    [ApiController]
    [Route("[controller]")] // Route: job
    public class JobController
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
    }
}
