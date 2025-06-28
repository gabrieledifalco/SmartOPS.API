using SmartOPS.API.DTO.Request.User;
using SmartOPS.API.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SmartOPS.API.DTO.Request.Company
{
    public class CompanyDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PIVA { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        // Admin credentials
        [Required]
        public UserAdminRegistrationDTO UserAdmin { get; set; }
    }
}
