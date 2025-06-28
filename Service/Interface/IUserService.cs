using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IUserService
    {
        Task<bool> UserRegistrationAsync(User user, string password);
        Task<User?> AuthenticateAsync(string email, string password);
        Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);
    }
}
