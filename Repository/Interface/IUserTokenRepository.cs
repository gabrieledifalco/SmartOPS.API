using SmartOPS.API.Model;

namespace SmartOPS.API.Repository.Interface
{
    public interface IUserTokenRepository
    {
        Task<UserToken?> GetByUserIdAsync(int userId);
        Task CreateOrUpdateAsync(UserToken token);
        Task DeleteAsync(UserToken token);
    }
}
