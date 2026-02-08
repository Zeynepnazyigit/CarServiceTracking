using CarServiceTracking.Core.DTOs.RentalDTOs;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<List<RentalVehicleListDTO>>> GetAllVehiclesAsync();
        Task<IDataResult<List<RentalVehicleListDTO>>> GetAvailableVehiclesAsync();
        Task<IDataResult<RentalVehicleDetailDTO>> GetVehicleByIdAsync(int id);
        Task<IDataResult<RentalVehicleDetailDTO>> CreateVehicleAsync(RentalVehicleCreateDTO dto);
        Task<IDataResult<RentalVehicleDetailDTO>> UpdateVehicleAsync(RentalVehicleUpdateDTO dto);
        Task<IResult> DeleteVehicleAsync(int id);

        Task<IDataResult<List<RentalAgreementListDTO>>> GetAllAgreementsAsync();
        Task<IDataResult<List<RentalAgreementListDTO>>> GetActiveAgreementsAsync();
        Task<IDataResult<List<RentalAgreementListDTO>>> GetByCustomerIdAsync(int customerId);
        Task<IDataResult<List<RentalAgreementListDTO>>> GetOverdueAgreementsAsync();
        Task<IDataResult<RentalAgreementDetailDTO>> GetAgreementByIdAsync(int id);
        Task<IDataResult<RentalAgreementDetailDTO>> CreateAgreementAsync(RentalAgreementCreateDTO dto);
        Task<IDataResult<RentalAgreementDetailDTO>> UpdateAgreementAsync(RentalAgreementUpdateDTO dto);
        Task<IResult> DeleteAgreementAsync(int id);
        Task<IResult> CompleteRentalAsync(int agreementId, int endMileage, DateTime returnDate);
    }
}
