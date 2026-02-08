using CarServiceTracking.Core.DTOs.PaymentDTOs;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IPaymentService
    {
        Task<IDataResult<List<PaymentListDTO>>> GetAllAsync();
        Task<IDataResult<List<PaymentListDTO>>> GetByInvoiceIdAsync(int invoiceId);
        Task<IDataResult<List<PaymentListDTO>>> GetByPaymentMethodAsync(PaymentMethod method);
        Task<IDataResult<List<PaymentListDTO>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        
        /// <summary>
        /// Müşteriye ait tüm ödemeleri getirir.
        /// İlişki: Payment → Invoice → ServiceRequest → Customer
        /// </summary>
        /// <param name="customerId">Müşteri ID</param>
        /// <returns>Müşterinin tüm ödemeleri</returns>
        Task<IDataResult<List<PaymentListDTO>>> GetByCustomerIdAsync(int customerId);
        
        Task<IDataResult<PaymentDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<PaymentDetailDTO>> CreateAsync(PaymentCreateDTO dto);
        Task<IDataResult<PaymentDetailDTO>> UpdateAsync(PaymentUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
    }
}
