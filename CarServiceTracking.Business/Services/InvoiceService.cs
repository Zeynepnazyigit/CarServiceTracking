using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.InvoiceDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<InvoiceListDTO>>> GetAllAsync()
        {
            var invoices = await _unitOfWork.Invoices.GetAllAsync();
            var invoiceDtos = new List<InvoiceListDTO>();

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                await PopulateInvoiceListDtoAsync(dto, invoice);
                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Faturalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<InvoiceListDTO>>> GetByServiceRequestIdAsync(int serviceRequestId)
        {
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => x.ServiceRequestId == serviceRequestId);
            var invoiceDtos = new List<InvoiceListDTO>();

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                await PopulateInvoiceListDtoAsync(dto, invoice);
                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Faturalar başarıyla listelendi.");
        }

        /// <summary>
        /// Musteriye ait tum faturalari getirir (servis + kiralama)
        /// CustomerId uzerinden direkt sorgular - her iki tur faturayi kapsar
        /// </summary>
        public async Task<IDataResult<List<InvoiceListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            // CustomerId uzerinden direkt sorgula - hem servis hem kiralama faturalari gelir
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => x.CustomerId == customerId);
            var invoiceDtos = new List<InvoiceListDTO>();

            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            var customerName = customer?.FullName ?? "Bilinmiyor";

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                dto.CustomerName = customerName;

                // Kiralama faturasi ise arac bilgisi ekle
                if (invoice.RentalAgreementId.HasValue)
                {
                    var rental = await _unitOfWork.RentalAgreements.GetByIdAsync(invoice.RentalAgreementId.Value);
                    if (rental != null)
                    {
                        var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(rental.RentalVehicleId);
                        dto.RentalInfo = $"{rental.AgreementNumber} - {vehicle?.DisplayName ?? "Bilinmiyor"}";
                    }
                }

                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Müşteri faturaları başarıyla listelendi.");
        }

        /// <summary>
        /// Musteriye ait odenmemis faturalari getirir (servis + kiralama)
        /// </summary>
        public async Task<IDataResult<List<InvoiceListDTO>>> GetPendingInvoicesByCustomerIdAsync(int customerId)
        {
            // CustomerId uzerinden direkt sorgula + odeme durumu filtresi
            var invoices = await _unitOfWork.Invoices.GetListAsync(x =>
                x.CustomerId == customerId &&
                (x.PaymentStatus == PaymentStatus.Pending || x.PaymentStatus == PaymentStatus.Partial));

            var invoiceDtos = new List<InvoiceListDTO>();

            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            var customerName = customer?.FullName ?? "Bilinmiyor";

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                dto.CustomerName = customerName;

                // Kiralama faturasi ise arac bilgisi ekle
                if (invoice.RentalAgreementId.HasValue)
                {
                    var rental = await _unitOfWork.RentalAgreements.GetByIdAsync(invoice.RentalAgreementId.Value);
                    if (rental != null)
                    {
                        var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(rental.RentalVehicleId);
                        dto.RentalInfo = $"{rental.AgreementNumber} - {vehicle?.DisplayName ?? "Bilinmiyor"}";
                    }
                }

                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Müşteriye ait bekleyen faturalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<InvoiceListDTO>>> GetByPaymentStatusAsync(PaymentStatus status)
        {
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => x.PaymentStatus == status);
            var invoiceDtos = new List<InvoiceListDTO>();

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                await PopulateInvoiceListDtoAsync(dto, invoice);
                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Faturalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<InvoiceListDTO>>> GetOverdueInvoicesAsync()
        {
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => 
                x.DueDate.HasValue && 
                x.DueDate.Value < DateTime.Now && 
                x.RemainingAmount > 0);

            var invoiceDtos = new List<InvoiceListDTO>();

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                await PopulateInvoiceListDtoAsync(dto, invoice);
                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Vadesi geçmiş faturalar başarıyla listelendi.");
        }

        public async Task<IDataResult<InvoiceDetailDTO>> GetByIdAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);

            if (invoice == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Fatura bulunamadı.");

            var dto = _mapper.Map<InvoiceDetailDTO>(invoice);

            // Musteri bilgisi (CustomerId uzerinden direkt)
            var customer = await _unitOfWork.Customers.GetByIdAsync(invoice.CustomerId);
            dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
            dto.CustomerPhone = customer?.Phone ?? "Bilinmiyor";

            // Servis faturasi ise arac bilgisi — Servis Talebi'nin CarId'si Car tablosuna baglidir (Opel Mokka vb.)
            if (invoice.ServiceRequestId.HasValue)
            {
                var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId.Value);
                if (serviceRequest != null)
                {
                    var car = await _unitOfWork.Cars.GetByIdAsync(serviceRequest.CarId);
                    dto.CarInfo = car != null ? $"{car.Brand} {car.Model}" : "Bilinmiyor";
                }
            }

            // Kiralama faturasi ise kiralama + arac bilgisi
            if (invoice.RentalAgreementId.HasValue)
            {
                var rental = await _unitOfWork.RentalAgreements.GetByIdAsync(invoice.RentalAgreementId.Value);
                if (rental != null)
                {
                    var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(rental.RentalVehicleId);
                    dto.RentalInfo = $"{rental.AgreementNumber} - {vehicle?.DisplayName ?? "Bilinmiyor"}";
                    dto.CarInfo = vehicle?.DisplayName ?? "Kiralık Araç";
                }
            }

            return new SuccessDataResult<InvoiceDetailDTO>(dto, "Fatura başarıyla getirildi.");
        }

        public async Task<IDataResult<InvoiceDetailDTO>> GetByInvoiceNumberAsync(string invoiceNumber)
        {
            var invoice = await _unitOfWork.Invoices.GetAsync(x => x.InvoiceNumber == invoiceNumber);

            if (invoice == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Fatura bulunamadı.");

            return await GetByIdAsync(invoice.Id);
        }

        public async Task<IDataResult<InvoiceDetailDTO>> CreateAsync(InvoiceCreateDTO dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            invoice.InvoiceNumber = await GenerateInvoiceNumberAsync();
            invoice.PaidAmount = 0m;
            invoice.PaymentStatus = PaymentStatus.Pending;

            CalculateInvoiceAmounts(invoice);

            var createdInvoice = await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(createdInvoice.Id);
            return new SuccessDataResult<InvoiceDetailDTO>(result.Data, "Fatura başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<InvoiceDetailDTO>> UpdateAsync(InvoiceUpdateDTO dto)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(dto.Id);

            if (invoice == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Fatura bulunamadı.");

            _mapper.Map(dto, invoice);
            CalculateInvoiceAmounts(invoice);
            invoice.ModifiedDate = DateTime.Now;

            await _unitOfWork.Invoices.UpdateAsync(invoice);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(invoice.Id);
            return new SuccessDataResult<InvoiceDetailDTO>(result.Data, "Fatura başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var success = await _unitOfWork.Invoices.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Fatura silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Fatura başarıyla silindi.");
        }

        public async Task<IDataResult<InvoiceDetailDTO>> CreateFromServiceRequestAsync(int serviceRequestId, bool replaceIfExists = false)
        {
            var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(serviceRequestId);
            if (serviceRequest == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Servis talebi bulunamadı.");

            var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
            if (customer == null || customer.IsDeleted)
                return new ErrorDataResult<InvoiceDetailDTO>("Bu servis talebine ait müşteri bulunamadı veya pasif. Fatura oluşturulamaz.");

            var existingInvoice = await _unitOfWork.Invoices.GetAsync(
                i => i.ServiceRequestId == serviceRequestId);
            if (existingInvoice != null)
            {
                if (!replaceIfExists)
                    return new ErrorDataResult<InvoiceDetailDTO>(
                        $"Bu servis talebi için zaten fatura mevcut: {existingInvoice.InvoiceNumber}. Yeniden oluşturmak için \"Mevcut faturayı silip yeniden oluştur\" seçeneğini işaretleyin.");

                // Replace: atomik işlem — önce sil, sonra oluştur; hata olursa rollback (clean code: tek sorumluluk, tutarlı durum)
                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    await _unitOfWork.Invoices.DeleteAsync(existingInvoice.Id);
                    var customerId = serviceRequest.CustomerId;
                    var totalCost = serviceRequest.ServicePrice ?? 0m;
                    var createDto = new InvoiceCreateDTO
                    {
                        ServiceRequestId = serviceRequestId,
                        CustomerId = customerId,
                        InvoiceDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(30),
                        LaborCost = 0m,
                        PartsTotal = totalCost,
                        TaxRate = 20m
                    };
                    var createResult = await CreateAsync(createDto);
                    if (!createResult.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return createResult;
                    }
                    await _unitOfWork.CommitAsync();
                    return createResult;
                }
                catch
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            }

            var customerIdFinal = serviceRequest.CustomerId;
            decimal totalCostFinal = serviceRequest.ServicePrice ?? 0m;
            var createDtoFinal = new InvoiceCreateDTO
            {
                ServiceRequestId = serviceRequestId,
                CustomerId = customerIdFinal,
                InvoiceDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                LaborCost = 0m,
                PartsTotal = totalCostFinal,
                TaxRate = 20m
            };

            return await CreateAsync(createDtoFinal);
        }

        /// <summary>
        /// Kiralama sozlesmesi icin otomatik fatura olusturur
        /// </summary>
        public async Task<IDataResult<InvoiceDetailDTO>> CreateRentalInvoiceAsync(int rentalAgreementId)
        {
            // Kiralama sozlesmesini kontrol et
            var rental = await _unitOfWork.RentalAgreements.GetByIdAsync(rentalAgreementId);
            if (rental == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Kiralama sözleşmesi bulunamadı.");

            // Ayni kiralama icin zaten fatura var mi kontrol et
            var existingInvoice = await _unitOfWork.Invoices.GetAsync(x => x.RentalAgreementId == rentalAgreementId);
            if (existingInvoice != null)
                return new ErrorDataResult<InvoiceDetailDTO>("Bu kiralama sözleşmesi için zaten bir fatura mevcut.");

            // Kiralama verilerinden fatura olustur
            var createDto = new InvoiceCreateDTO
            {
                RentalAgreementId = rentalAgreementId,
                ServiceRequestId = null,
                CustomerId = rental.CustomerId,
                InvoiceDate = DateTime.Now,
                DueDate = rental.EndDate,
                LaborCost = rental.TotalAmount,   // Kiralama ucreti
                PartsTotal = rental.DepositAmount, // Depozito
                TaxRate = 0m,                      // Kiralama icin KDV yok (gerekirse degistirilebilir)
                Notes = $"Kiralama Sözleşmesi: {rental.AgreementNumber}"
            };

            return await CreateAsync(createDto);
        }

        // ==========================================
        // HELPER METOTLAR
        // ==========================================

        /// <summary>
        /// Fatura listesi DTO'suna musteri ve kiralama bilgisi ekler
        /// </summary>
        private async Task PopulateInvoiceListDtoAsync(InvoiceListDTO dto, Invoice invoice)
        {
            // Musteri bilgisi (CustomerId uzerinden direkt)
            var customer = await _unitOfWork.Customers.GetByIdAsync(invoice.CustomerId);
            dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

            // Kiralama faturasi ise ek bilgi
            if (invoice.RentalAgreementId.HasValue)
            {
                var rental = await _unitOfWork.RentalAgreements.GetByIdAsync(invoice.RentalAgreementId.Value);
                if (rental != null)
                {
                    var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(rental.RentalVehicleId);
                    dto.RentalInfo = $"{rental.AgreementNumber} - {vehicle?.DisplayName ?? "Bilinmiyor"}";
                }
            }
        }

        /// <summary>
        /// Benzersiz fatura numarası üretir. Silinmiş (soft-delete) faturalar dahil tüm kayıtlar dikkate alınır;
        /// böylece "mevcut faturayı silip yeniden oluştur" sonrası numara çakışması olmaz.
        /// </summary>
        private async Task<string> GenerateInvoiceNumberAsync()
        {
            var now = DateTime.Now;
            var prefix = $"INV{now:yyyyMM}";

            var allWithPrefix = await _unitOfWork.Invoices.GetListIncludingDeletedAsync(x => x.InvoiceNumber.StartsWith(prefix));
            var lastInvoice = allWithPrefix.OrderByDescending(x => x.InvoiceNumber).FirstOrDefault();

            if (lastInvoice == null)
                return $"{prefix}0001";

            var lastNumber = int.Parse(lastInvoice.InvoiceNumber.Substring(prefix.Length));
            return $"{prefix}{(lastNumber + 1):0000}";
        }

        private void CalculateInvoiceAmounts(Invoice invoice)
        {
            invoice.SubTotal = invoice.LaborCost + invoice.PartsTotal;

            invoice.TaxAmount = invoice.SubTotal * (invoice.TaxRate / 100);
            invoice.GrandTotal = invoice.SubTotal + invoice.TaxAmount;

            invoice.RemainingAmount = invoice.GrandTotal - invoice.PaidAmount;

            if (invoice.PaidAmount > 0 && invoice.RemainingAmount <= 0)
                invoice.PaymentStatus = PaymentStatus.Paid;
            else if (invoice.PaidAmount > 0 && invoice.RemainingAmount > 0)
                invoice.PaymentStatus = PaymentStatus.Partial;
            else
                invoice.PaymentStatus = PaymentStatus.Pending;
        }
    }
}
