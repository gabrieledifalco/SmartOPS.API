﻿using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Data;
using SmartOPS.API.Model;
using SmartOPS.API.Repository.Interface;

namespace SmartOPS.API.Repository.Implementation
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdatePasswordAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
