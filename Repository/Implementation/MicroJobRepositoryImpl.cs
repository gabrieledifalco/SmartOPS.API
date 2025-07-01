using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class MicroJobRepositoryImpl : IMicroJobRepository
    {
        private readonly AppDbContext _context;

        public MicroJobRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MicroJob microJob)
        {
            await _context.MicroJobs.AddAsync(microJob);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int microJobId, int companyId)
        {
            var microJob = await _context.MicroJobs.FirstOrDefaultAsync(mj => mj.Id == microJobId && mj.CompanyId == companyId);
            if(microJob != null)
            {
                _context.MicroJobs.Remove(microJob);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MicroJob> GetByIdAsync(int microJobId, int companyId)
        {
            return await _context.MicroJobs.Include(mj => mj.Job).FirstOrDefaultAsync(mj => mj.Id == microJobId && mj.CompanyId == companyId);
        }

        public async Task<IEnumerable<MicroJob>> GetByJobIdAsync(int jobId, int companyId)
        {
            return await _context.MicroJobs.Where(mj => mj.Id == jobId && mj.CompanyId == companyId).ToListAsync();
        }

        public async Task UpdateAsync(MicroJob microJob)
        {
            _context.MicroJobs.Update(microJob);
            await _context.SaveChangesAsync();
        }
    }
}
