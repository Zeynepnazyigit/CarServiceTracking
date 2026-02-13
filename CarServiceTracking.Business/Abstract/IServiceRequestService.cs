using CarServiceTracking.Utilities.Results;
using CarServiceTracking.Core.DTOs.ServiceRequestDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Abstract
{
    public interface IServiceRequestService
    {
        Task<IResult> CreateAsync(ServiceRequestCreateDTO dto);
        Task<IDataResult<List<ServiceRequestListDTO>>> GetAllAsync();
        Task<IDataResult<ServiceRequestDetailDTO>> GetByIdAsync(int id);
        Task<IResult> UpdateAsync(int id, ServiceRequestUpdateDTO dto);
        Task<IResult> UpdateStatusAsync(int id, int status, decimal? servicePrice, string? adminNote);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<List<ServiceRequestListDTO>>> GetByCustomerIdAsync(int customerId);
    }
}
