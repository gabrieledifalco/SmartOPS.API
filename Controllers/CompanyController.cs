using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOPS.API.DTO.Request.Company;
using SmartOPS.API.Model;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Controllers
{
    [ApiController]
    [Route("[controller]")] // Route company
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public CompanyController(ICompanyService companyService, IUserService userService)
        {
            _companyService = companyService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CompanyRegistration([FromBody] CompanyDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var company = new Company
            {
                Name = dto.Name,
                PIVA = dto.PIVA,
                Address = dto.Address,
                City = dto.City,
                Province = dto.Province,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                Email = dto.Email,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow
            };

            var createdCompany = await _companyService.CompanyRegistrationAsync(company);
            if (createdCompany == null) return BadRequest("Error during Company registration");

            var userAdmin = new User
            {
                Email = dto.UserAdmin.Email,
                CompanyId = createdCompany.Id,
                Role = dto.UserAdmin.Role,
                PasswordHash = dto.UserAdmin.Password
            };

            var userCreated = await _userService.UserRegistrationAsync(userAdmin, dto.UserAdmin.Password);
            if(!userCreated) return BadRequest("Error during Admin registration");

            return Ok(new { message = "Company registered with success" });
        }

        // todo: rimozione compagnia e di tutti gli user associati
    }
}
