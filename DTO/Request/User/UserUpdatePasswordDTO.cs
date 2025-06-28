using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.User
{
    public class UserUpdatePasswordDTO
    {
        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; }
        [Required]
        public string OldPassword { get; set; }
    }
}
