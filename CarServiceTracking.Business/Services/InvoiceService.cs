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

                var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId);
                if (serviceRequest != null)
                {
                    var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
                    dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
                }

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

                var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId);
                if (serviceRequest != null)
                {
                    var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
                    dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
                }

                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Faturalar başarıyla listelendi.");
        }

        /// <summary>
        /// Müşteriye ait faturaları getirir
        /// Clean Code: Single Responsibility - Sadece müşteri faturalarını filtreler
        /// </summary>
        public async Task<IDataResult<List<InvoiceListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            // Önce müşterinin servis taleplerini bul
            var serviceRequests = await _unitOfWork.ServiceRequests.GetListAsync(x => x.CustomerId == customerId);
            var serviceRequestIds = serviceRequests.Select(x => x.Id).ToList();

            // Bu servis taleplerine ait faturaları getir
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => serviceRequestIds.Contains(x.ServiceRequestId));
            var invoiceDtos = new List<InvoiceListDTO>();

            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            var customerName = customer?.FullName ?? "Bilinmiyor";

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);
                dto.CustomerName = customerName;
                invoiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<InvoiceListDTO>>(invoiceDtos, "Müşteri faturaları başarıyla listelendi.");
        }

        public async Task<IDataResult<List<InvoiceListDTO>>> GetByPaymentStatusAsync(PaymentStatus status)
        {
            var invoices = await _unitOfWork.Invoices.GetListAsync(x => x.PaymentStatus == status);
            var invoiceDtos = new List<InvoiceListDTO>();

            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate))
            {
                var dto = _mapper.Map<InvoiceListDTO>(invoice);

                var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId);
                if (serviceRequest != null)
                {
                    var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
                    dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
                }

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

                var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId);
                if (serviceRequest != null)
                {
                    var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
                    dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
                }

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

            var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(invoice.ServiceRequestId);
            if (serviceRequest != null)
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(serviceRequest.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
                dto.CustomerPhone = customer?.Phone ?? "Bilinmiyor";

                var customerCar = await _unitOfWork.CustomerCars.GetByIdAsync(serviceRequest.CarId);
                dto.CarInfo = customerCar?.BrandModel ?? "Bilinmiyor";
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

        public async Task<IDataResult<InvoiceDetailDTO>> CreateFromServiceRequestAsync(int serviceRequestId)
        {
            var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(serviceRequestId);
            if (serviceRequest == null)
                return new ErrorDataResult<InvoiceDetailDTO>("Servis talebi bulunamadı.");

            var serviceParts = await _unitOfWork.ServiceParts.GetListAsync(x => x.ServiceRequestId == serviceRequestId);
            var partsCost = serviceParts.Sum(x => x.Quantity * x.UnitPrice);

            var createDto = new InvoiceCreateDTO
            {
                ServiceRequestId = serviceRequestId,
                InvoiceDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                LaborCost = 0m,
                PartsTotal = partsCost,
                TaxRate = 20m
            };

            return await CreateAsync(createDto);
        }

        private async Task<string> GenerateInvoiceNumberAsync()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var prefix = $"INV{year}{month:00}";

            var lastInvoice = (await _unitOfWork.Invoices.GetListAsync(x => x.InvoiceNumber.StartsWith(prefix)))
                .OrderByDescending(x => x.InvoiceNumber)
                .FirstOrDefault();

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

            if (invoice.RemainingAmount <= 0)
                invoice.PaymentStatus = PaymentStatus.Paid;
            else if (invoice.PaidAmount > 0)
                invoice.PaymentStatus = PaymentStatus.Partial;
            else if (invoice.DueDate.HasValue && invoice.DueDate.Value < DateTime.Now)
                invoice.PaymentStatus = PaymentStatus.Overdue;
            else
                invoice.PaymentStatus = PaymentStatus.Pending;
        }
    }
}
