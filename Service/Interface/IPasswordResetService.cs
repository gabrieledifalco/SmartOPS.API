namespace SmartOPS.API.Service.Interface
{
    public interface IPasswordResetService
    {
        Task<bool> GenerateTokenAsync(string email);
        Task<bool> ResetPasswordAsync(string token, string newPassword, string oldPassword);
    }
}
