using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarServiceTracking.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Email'e göre kullanıcı bul
        /// </summary>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        /// <summary>
        /// ID'ye göre kullanıcı bul
        /// </summary>
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);
        }

        /// <summary>
        /// Email'in var olup olmadığını kontrol et
        /// </summary>
        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return await _context.Users
                .AnyAsync(u => u.Email == email && !u.IsDeleted);
        }
    }
}
