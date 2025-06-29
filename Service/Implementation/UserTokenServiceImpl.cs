using Microsoft.IdentityModel.Tokens;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartOPS.API.Service.Implementation
{
    public class UserTokenServiceImpl : IUserTokenService
    {
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IConfiguration _config;

        public UserTokenServiceImpl(IUserTokenRepository userTokenRepository, IConfiguration config)
        {
            _userTokenRepository = userTokenRepository;
            _config = config;
        }

        public async Task<string?> AuthenticateAndGenerateTokenAsync(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("CompanyId", user.CompanyId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExipiresInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var userToken = new UserToken
            {
                UserId = user.Id,
                Token = tokenString,
                CreatedAt = DateTime.UtcNow,
                ExiperesAt = expires,
                IsRevoked = false
            };

            await _userTokenRepository.CreateOrUpdateAsync(userToken);
            return tokenString;
        }
    }
}
