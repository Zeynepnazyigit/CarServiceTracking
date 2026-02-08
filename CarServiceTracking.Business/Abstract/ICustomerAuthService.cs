using System.Threading.Tasks;
using CarServiceTracking.Core.DTOs.AuthDTOs;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface ICustomerAuthService
    {
        Task<IResult> SignupAsync(CustomerSignupDTO dto);

        Task<IDataResult<AuthLoginResponseDTO>> LoginAsync(CustomerLoginDTO dto);
    }
}
