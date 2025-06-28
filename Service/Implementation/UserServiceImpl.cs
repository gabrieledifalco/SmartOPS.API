using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Service.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null) return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return isPasswordValid ? user : null;
        }

        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            var existingUser = await _userRepository.GetByEmail(email);
            if (existingUser == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, existingUser.PasswordHash)) return false;

            var hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            existingUser.PasswordHash = hashedNewPassword;
            await _userRepository.UpdatePasswordAsync(existingUser);

            return true;
        }

        public async Task<bool> UserRegistrationAsync(User user, string password)
        {
            if(await _userRepository.GetByEmail(user.Email) != null)
            {
                return false;
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            await _userRepository.CreateAsync(user);

            return true;
        }
    }
}
