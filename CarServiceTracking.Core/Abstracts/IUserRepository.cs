using CarServiceTracking.Core.Entities;
using System.Threading.Tasks;

namespace CarServiceTracking.Core.Abstracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int userId);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}
