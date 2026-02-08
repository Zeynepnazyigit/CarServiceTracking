using CarServiceTracking.Core.DTOs.AppointmentDTOs;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IAppointmentService
    {
        Task<IDataResult<List<AppointmentListDTO>>> GetAllAsync();
        Task<IDataResult<List<AppointmentListDTO>>> GetByCustomerIdAsync(int customerId);
        Task<IDataResult<List<AppointmentListDTO>>> GetByDateAsync(DateTime date);
        Task<IDataResult<List<AppointmentListDTO>>> GetByStatusAsync(AppointmentStatus status);
        Task<IDataResult<AppointmentDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<AppointmentDetailDTO>> CreateAsync(AppointmentCreateDTO dto);
        Task<IDataResult<AppointmentDetailDTO>> UpdateAsync(AppointmentUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> ConfirmAppointmentAsync(int id);
        Task<IResult> CancelAppointmentAsync(int id, string reason);
    }
}
