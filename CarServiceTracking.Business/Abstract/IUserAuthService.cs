using System.Threading.Tasks;
using CarServiceTracking.Core.DTOs.AuthDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IUserAuthService
    {
        Task<IDataResult<AuthLoginResponseDTO>> LoginAsync(string email, string password);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
