using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class UserTokenRepositoryImpl : IUserTokenRepository
    {
        private readonly AppDbContext _context;

        public UserTokenRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserToken?> GetByUserIdAsync(int userId)
        {
            return await _context.UserTokens.FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task CreateOrUpdateAsync(UserToken token)
        {
            var existing = await GetByUserIdAsync(token.UserId);

            if(existing != null)
            {
                existing.Token = token.Token;
                existing.CreatedAt = token.CreatedAt;
                existing.ExiperesAt = token.ExiperesAt;
                existing.IsRevoked = false;
                existing.DeviseInfo = token.DeviseInfo;
                existing.IpAddress = token.IpAddress;
                _context.UserTokens.Update(existing);
            }
            else
            {
                await _context.UserTokens.AddAsync(token);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserToken token)
        {
            _context.UserTokens.Remove(token);
            await _context.SaveChangesAsync();
        }
    }
}
