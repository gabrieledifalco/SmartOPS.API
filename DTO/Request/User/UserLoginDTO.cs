using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
