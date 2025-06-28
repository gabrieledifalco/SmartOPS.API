using SmartOPS.API.Model;

namespace SmartOPS.API.Service.Interface
{
    public interface IUserTokenService
    {
        Task<string?> AuthenticateAndGenerateTokenAsync(User user);
    }
}
