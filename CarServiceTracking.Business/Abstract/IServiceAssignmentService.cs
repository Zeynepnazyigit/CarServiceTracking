using CarServiceTracking.Core.DTOs.ServiceAssignmentDTOs;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IServiceAssignmentService
    {
        Task<IDataResult<List<ServiceAssignmentListDTO>>> GetByServiceRequestIdAsync(int serviceRequestId);
        Task<IResult> AssignAsync(ServiceAssignmentCreateDTO dto);
        Task<IResult> RemoveAsync(int id);
    }
}
