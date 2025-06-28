using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class CompanyServiceImpl : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServiceImpl(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company?> CompanyRegistrationAsync(Company company)
        {
            if(await _companyRepository.GetByEmail(company.Email) != null)
            {
                return null;
            }

            var saved = await _companyRepository.CreateAsync(company);
            return saved;
        }
    }
}
