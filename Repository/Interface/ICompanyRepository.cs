using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<Company?> CreateAsync(Company company);
        Task<Company?> GetByEmail(string email);
    }
}
