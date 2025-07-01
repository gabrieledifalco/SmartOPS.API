using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class JobResultRepositoryImpl : IJobResultRepository
    {
        private readonly AppDbContext _context;

        public JobResultRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(JobResult jobResult)
        {
            await _context.JobResults.AddAsync(jobResult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobResult>> GetByJobIdAsync(int jobId)
        {
            return await _context.JobResults.Where(jr => jr.Id == jobId).ToListAsync();
        }
    }
}
