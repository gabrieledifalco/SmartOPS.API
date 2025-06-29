using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByEmail(string email);
        Task CreateAsync(User user);
        Task UpdatePasswordAsync(User user);
    }
}
