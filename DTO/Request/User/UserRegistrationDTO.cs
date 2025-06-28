using SmartOPS.API.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class UserRegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
