using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface ICompanyService
    {
        Task<Company?> CompanyRegistrationAsync(Company company);
    }
}
