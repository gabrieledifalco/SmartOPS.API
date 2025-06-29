using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartOPS.API.DTO.Request.User;
using SmartOPS.API.DTO.Response;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartOPS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")] // Route user
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IPasswordResetService _passwordResetService;
        private readonly IUserTokenRepository _userTokenRepository;

        public UserController(IUserService userService, IPasswordResetService passwordResetService, IConfiguration config, IUserTokenRepository userTokenRepository)
        {
            _userService = userService;
            _passwordResetService = passwordResetService;
            _config = config;
            _userTokenRepository = userTokenRepository;
        }

        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous] // Only for testing
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO dto)
        {
            var user = new User
            {
                Email = dto.Email,
                CompanyId = dto.CompanyId,
                PasswordHash = dto.Password,
                Role = dto.Role
            };

            var result = await _userService.UserRegistrationAsync(user, dto.Password);

            if(!result)
            {
                return BadRequest("User already registered");
            }

            return Ok("Registration completed");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            var user = await _userService.AuthenticateAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized("Credentials not valid");

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("CompanyId", user.CompanyId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var userToken = new UserToken
            {
                UserId = user.Id,
                Token = tokenString,
                CreatedAt = DateTime.UtcNow,
                ExiperesAt = expiresAt,
                IsRevoked = false,
                DeviseInfo = Request.Headers["User-Agent"].ToString(),
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString()
            };

            await _userTokenRepository.CreateOrUpdateAsync(userToken);

            return Ok(new AuthResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = user.Role.ToString(),
                Email = user.Email
            });
        }

        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IActionResult> restorePassword([FromBody] UserUpdatePasswordDTO dto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email)) return Unauthorized("Missing email in token");

            var result = await _userService.ChangePasswordAsync(email, dto.OldPassword, dto.NewPassword);
            if (!result) return BadRequest("Error during the password Update");

            return Ok("Password changed");
        }

        [AllowAnonymous]
        [HttpPost("requestResetPassword")]
        public async Task<IActionResult> RequestResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var result = await _passwordResetService.GenerateTokenAsync(dto.Email);
            if (!result) return BadRequest("User not found");

            // todo: implementare sistema email
            return Ok("Reset token generated");
        }

        [AllowAnonymous]
        [HttpPost("confirmResetPassword")]
        public async Task<IActionResult> ConfirmReset([FromBody] ConfirmResetPasswordDTO dto)
        {
            var result = await _passwordResetService.ResetPasswordAsync(dto.Token, dto.NewPassword, dto.OldPassword);
            if (!result) return BadRequest("Invalid or exipered token, or wrong old password");

            return Ok("Password updated successfully");
        }
    }
}
