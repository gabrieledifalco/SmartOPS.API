using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class JobRepositoryImpl : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int jobId, int companyId)
        {
            var jobs = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobId && j.CompanyId == companyId);
            if(jobs != null)
            {
                _context.Jobs.Remove(jobs);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Job>> GetAllByCompanyAsync(int companyId)
        {
            return await _context.Jobs.Where(j => j.CompanyId == companyId).Include(j => j.MicroJobs).Include(j => j.Results).ToListAsync();
        }

        public async Task<Job> GetByIdAsync(int jobId, int companyId)
        {
            return await _context.Jobs.Include(j => j.MicroJobs).Include(j => j.Results).FirstOrDefaultAsync(j => j.Id == jobId && j.CompanyId == companyId);
        }

        public async Task UpdateAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}
