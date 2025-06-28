using SmartOPS.API.Data;
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

    }
}
