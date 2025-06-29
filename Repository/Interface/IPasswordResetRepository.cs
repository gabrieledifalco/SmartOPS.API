using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IPasswordResetRepository
    {
        Task<PasswordResetToken?> GetByTokenAsync(string token);
        Task CreateAsync(PasswordResetToken token);
        Task MarkAsUsedAsync(PasswordResetToken token);
        Task<User?> GetUserByEmailAsync(string email);
        Task UpdateUserPasswordAsync(User user);
    }
}
