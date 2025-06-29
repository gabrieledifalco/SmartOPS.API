using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class ConfirmResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; }
        [Required]
        public string OldPassword { get; set; }
    }
}
