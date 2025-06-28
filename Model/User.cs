using SmartOPS.API.Model.Enum;

namespace SmartOPS.API.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } // Admin, Operator, Viewer
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public UserToken Token { get; set; }
    }
}
