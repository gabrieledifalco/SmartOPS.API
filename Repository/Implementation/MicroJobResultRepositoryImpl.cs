using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class MicroJobResultRepositoryImpl : IMicroJobResultRepository
    {
        private readonly AppDbContext _context;

        public MicroJobResultRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MicroJobResult microJobResult)
        {
            await _context.MicroJobResults.AddAsync(microJobResult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MicroJobResult>> GetByMicroJobIdAsync(int microJobId)
        {
            return await _context.MicroJobResults.Where(mjr => mjr.MicroJobId == microJobId).ToListAsync();
        }
    }
}
