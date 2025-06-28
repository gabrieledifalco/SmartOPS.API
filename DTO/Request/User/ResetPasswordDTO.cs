using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class ResetPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
