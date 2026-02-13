using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.PaymentDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<PaymentListDTO>>> GetAllAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            var paymentDtos = new List<PaymentListDTO>();

            foreach (var payment in payments.OrderByDescending(x => x.PaymentDate))
            {
                var dto = _mapper.Map<PaymentListDTO>(payment);

                var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
                dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";

                paymentDtos.Add(dto);
            }

            return new SuccessDataResult<List<PaymentListDTO>>(paymentDtos, "Ödemeler başarıyla listelendi.");
        }

        public async Task<IDataResult<List<PaymentListDTO>>> GetByInvoiceIdAsync(int invoiceId)
        {
            var payments = await _unitOfWork.Payments.GetListAsync(x => x.InvoiceId == invoiceId);
            var paymentDtos = new List<PaymentListDTO>();

            foreach (var payment in payments.OrderByDescending(x => x.PaymentDate))
            {
                var dto = _mapper.Map<PaymentListDTO>(payment);

                var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
                dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";

                paymentDtos.Add(dto);
            }

            return new SuccessDataResult<List<PaymentListDTO>>(paymentDtos, "Ödemeler başarıyla listelendi.");
        }

        public async Task<IDataResult<List<PaymentListDTO>>> GetByPaymentMethodAsync(PaymentMethod method)
        {
            var payments = await _unitOfWork.Payments.GetListAsync(x => x.PaymentMethod == method);
            var paymentDtos = new List<PaymentListDTO>();

            foreach (var payment in payments.OrderByDescending(x => x.PaymentDate))
            {
                var dto = _mapper.Map<PaymentListDTO>(payment);

                var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
                dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";

                paymentDtos.Add(dto);
            }

            return new SuccessDataResult<List<PaymentListDTO>>(paymentDtos, "Ödemeler başarıyla listelendi.");
        }

        public async Task<IDataResult<List<PaymentListDTO>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var payments = await _unitOfWork.Payments.GetListAsync(x => 
                x.PaymentDate >= startDate && 
                x.PaymentDate <= endDate);

            var paymentDtos = new List<PaymentListDTO>();

            foreach (var payment in payments.OrderByDescending(x => x.PaymentDate))
            {
                var dto = _mapper.Map<PaymentListDTO>(payment);

                var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
                dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";

                paymentDtos.Add(dto);
            }

            return new SuccessDataResult<List<PaymentListDTO>>(paymentDtos, "Ödemeler başarıyla listelendi.");
        }

        /// <summary>
        /// Musteriye ait tum odemeleri getirir (servis + kiralama faturalari)
        /// CustomerId uzerinden direkt sorgular
        /// </summary>
        public async Task<IDataResult<List<PaymentListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            // 1. Musterinin tum faturalarini bul (servis + kiralama)
            var invoices = await _unitOfWork.Invoices.GetListAsync(inv => inv.CustomerId == customerId);
            var invoiceIds = invoices.Select(inv => inv.Id).ToList();

            if (!invoiceIds.Any())
                return new SuccessDataResult<List<PaymentListDTO>>(new List<PaymentListDTO>(), "Müşteriye ait ödeme bulunamadı.");

            // 2. Bu faturalara ait odemeleri getir
            var payments = await _unitOfWork.Payments.GetListAsync(p => invoiceIds.Contains(p.InvoiceId));

            var paymentDtos = new List<PaymentListDTO>();

            foreach (var payment in payments.OrderByDescending(x => x.PaymentDate))
            {
                var dto = _mapper.Map<PaymentListDTO>(payment);
                var invoice = invoices.FirstOrDefault(inv => inv.Id == payment.InvoiceId);
                dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";
                paymentDtos.Add(dto);
            }

            return new SuccessDataResult<List<PaymentListDTO>>(paymentDtos, "Müşteriye ait ödemeler başarıyla listelendi.");
        }

        public async Task<IDataResult<PaymentDetailDTO>> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            if (payment == null)
                return new ErrorDataResult<PaymentDetailDTO>("Ödeme bulunamadı.");

            var dto = _mapper.Map<PaymentDetailDTO>(payment);

            var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
            dto.InvoiceNumber = invoice?.InvoiceNumber ?? "Bilinmiyor";

            if (invoice != null)
            {
                // Musteri bilgisini direkt CustomerId uzerinden al
                var customer = await _unitOfWork.Customers.GetByIdAsync(invoice.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
            }

            return new SuccessDataResult<PaymentDetailDTO>(dto, "Ödeme başarıyla getirildi.");
        }

        public async Task<IDataResult<PaymentDetailDTO>> CreateAsync(PaymentCreateDTO dto)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(dto.InvoiceId);
            if (invoice == null)
                return new ErrorDataResult<PaymentDetailDTO>("Fatura bulunamadı.");

            if (dto.Amount <= 0)
                return new ErrorDataResult<PaymentDetailDTO>("Ödeme tutarı sıfırdan büyük olmalıdır.");

            if (dto.Amount > invoice.RemainingAmount)
                return new ErrorDataResult<PaymentDetailDTO>($"Ödeme tutarı kalan bakiyeden ({invoice.RemainingAmount:C}) fazla olamaz.");

            var payment = _mapper.Map<Payment>(dto);

            var createdPayment = await _unitOfWork.Payments.AddAsync(payment);

            invoice.PaidAmount += dto.Amount;
            invoice.RemainingAmount = invoice.GrandTotal - invoice.PaidAmount;

            if (invoice.RemainingAmount <= 0)
                invoice.PaymentStatus = PaymentStatus.Paid;
            else if (invoice.PaidAmount > 0)
                invoice.PaymentStatus = PaymentStatus.Partial;

            invoice.ModifiedDate = DateTime.Now;
            await _unitOfWork.Invoices.UpdateAsync(invoice);

            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(createdPayment.Id);
            return new SuccessDataResult<PaymentDetailDTO>(result.Data, "Ödeme başarıyla kaydedildi.");
        }

        public async Task<IDataResult<PaymentDetailDTO>> UpdateAsync(PaymentUpdateDTO dto)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(dto.Id);

            if (payment == null)
                return new ErrorDataResult<PaymentDetailDTO>("Ödeme bulunamadı.");

            var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
            if (invoice == null)
                return new ErrorDataResult<PaymentDetailDTO>("Fatura bulunamadı.");

            if (dto.Amount <= 0)
                return new ErrorDataResult<PaymentDetailDTO>("Ödeme tutarı sıfırdan büyük olmalıdır.");

            var oldAmount = payment.Amount;
            var amountDifference = dto.Amount - oldAmount;

            var newRemainingAmount = invoice.RemainingAmount - amountDifference;
            if (newRemainingAmount < 0)
                return new ErrorDataResult<PaymentDetailDTO>($"Yeni ödeme tutarı kalan bakiyeyi aşıyor.");

            _mapper.Map(dto, payment);
            payment.ModifiedDate = DateTime.Now;

            invoice.PaidAmount += amountDifference;
            invoice.RemainingAmount = invoice.GrandTotal - invoice.PaidAmount;

            if (invoice.RemainingAmount <= 0)
                invoice.PaymentStatus = PaymentStatus.Paid;
            else if (invoice.PaidAmount > 0)
                invoice.PaymentStatus = PaymentStatus.Partial;
            else
                invoice.PaymentStatus = PaymentStatus.Pending;

            invoice.ModifiedDate = DateTime.Now;

            await _unitOfWork.Payments.UpdateAsync(payment);
            await _unitOfWork.Invoices.UpdateAsync(invoice);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(payment.Id);
            return new SuccessDataResult<PaymentDetailDTO>(result.Data, "Ödeme başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
                return new ErrorResult("Ödeme bulunamadı.");

            var invoice = await _unitOfWork.Invoices.GetByIdAsync(payment.InvoiceId);
            if (invoice != null)
            {
                invoice.PaidAmount -= payment.Amount;
                invoice.RemainingAmount = invoice.GrandTotal - invoice.PaidAmount;

                if (invoice.RemainingAmount <= 0)
                    invoice.PaymentStatus = PaymentStatus.Paid;
                else if (invoice.PaidAmount > 0)
                    invoice.PaymentStatus = PaymentStatus.Partial;
                else
                    invoice.PaymentStatus = PaymentStatus.Pending;

                invoice.ModifiedDate = DateTime.Now;
                await _unitOfWork.Invoices.UpdateAsync(invoice);
            }

            var success = await _unitOfWork.Payments.DeleteAsync(id);
            if (!success)
                return new ErrorResult("Ödeme silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Ödeme başarıyla silindi ve fatura bakiyesi güncellendi.");
        }
    }
}
