using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class PasswordResetServiceImpl : IPasswordResetService
    {
        private readonly IPasswordResetRepository _passwordResetRepository;

        public PasswordResetServiceImpl(IPasswordResetRepository passwordResetRepository)
        {
            _passwordResetRepository = passwordResetRepository;
        }

        public async Task<bool> GenerateTokenAsync(string email)
        {
            var user = await _passwordResetRepository.GetUserByEmailAsync(email);
            if (user == null) return false;

            var token = new PasswordResetToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(30),
                Used = false
            };

            await _passwordResetRepository.CreateAsync(token);
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword, string oldPassword)
        {
            var tokenEntity = await _passwordResetRepository.GetByTokenAsync(token);
            if (tokenEntity == null || tokenEntity.Used || tokenEntity.ExpiresAt < DateTime.UtcNow) return false;

            var user = tokenEntity.User;

            if(!BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash)) return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _passwordResetRepository.UpdateUserPasswordAsync(user);
            await _passwordResetRepository.MarkAsUsedAsync(tokenEntity);

            return true;
        }
    }
}
