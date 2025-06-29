using SmartOPS.API.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class UserAdminRegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        //[Required]
        //public int CompanyId { get; set; }
        public UserRole Role { get; set; } = UserRole.Admin;
    }
}
