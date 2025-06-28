using SmartOPS.API.Model;
using SmartOPS.API.Model.Enum;

namespace SmartOPS.API.DTO.Response
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public int CompanyId { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
