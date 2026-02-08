using CarServiceTracking.Core.DTOs.InvoiceDTOs;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<IDataResult<List<InvoiceListDTO>>> GetAllAsync();
        Task<IDataResult<List<InvoiceListDTO>>> GetByCustomerIdAsync(int customerId);
        Task<IDataResult<List<InvoiceListDTO>>> GetByServiceRequestIdAsync(int serviceRequestId);
        Task<IDataResult<List<InvoiceListDTO>>> GetByPaymentStatusAsync(PaymentStatus status);
        Task<IDataResult<List<InvoiceListDTO>>> GetOverdueInvoicesAsync();
        Task<IDataResult<InvoiceDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<InvoiceDetailDTO>> GetByInvoiceNumberAsync(string invoiceNumber);
        Task<IDataResult<InvoiceDetailDTO>> CreateAsync(InvoiceCreateDTO dto);
        Task<IDataResult<InvoiceDetailDTO>> UpdateAsync(InvoiceUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<InvoiceDetailDTO>> CreateFromServiceRequestAsync(int serviceRequestId);
    }
}
