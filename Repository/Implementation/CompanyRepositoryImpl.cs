using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class CompanyRepositoryImpl : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> GetByEmail(string email)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Email == email);

        }
    }
}
