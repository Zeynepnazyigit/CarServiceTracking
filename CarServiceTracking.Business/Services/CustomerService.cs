using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<CustomerListDTO>>> GetAllAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            var customerList = customers.ToList();
            var customerDtos = _mapper.Map<List<CustomerListDTO>>(customerList);
            
            // Her müşteri için araç ve servis sayılarını hesapla
            foreach (var dto in customerDtos)
            {
                var cars = await _unitOfWork.Cars.GetListAsync(c => c.CustomerId == dto.Id && !c.IsDeleted);
                dto.TotalVehicles = cars.Count();
                
                var serviceRequests = await _unitOfWork.ServiceRequests.GetListAsync(s => s.CustomerId == dto.Id && !s.IsDeleted);
                dto.TotalServices = serviceRequests.Count();
            }
            
            return new SuccessDataResult<List<CustomerListDTO>>(customerDtos, "Müşteriler başarıyla listelendi.");
        }

        public async Task<IDataResult<List<CustomerListDTO>>> GetActiveCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetListAsync(c => c.IsActive);
            var customerList = customers.ToList();
            var customerDtos = _mapper.Map<List<CustomerListDTO>>(customerList);
            return new SuccessDataResult<List<CustomerListDTO>>(customerDtos, "Aktif müşteriler başarıyla listelendi.");
        }

        public async Task<IDataResult<List<CustomerListItemDTO>>> GetCustomerListItemsAsync()
        {
            var customers = await _unitOfWork.Customers.GetListAsync(c => c.IsActive);
            var customerList = customers.ToList();
            var customerDtos = _mapper.Map<List<CustomerListItemDTO>>(customerList);
            return new SuccessDataResult<List<CustomerListItemDTO>>(customerDtos);
        }

        public async Task<IDataResult<CustomerDetailDTO>> GetByIdAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                return new ErrorDataResult<CustomerDetailDTO>("Müşteri bulunamadı.");

            if (customer.IsDeleted)
                return new ErrorDataResult<CustomerDetailDTO>("Müşteri silinmiş.");

            var customerDto = _mapper.Map<CustomerDetailDTO>(customer);
            
            // Araç ve servis istatistiklerini hesapla
            var cars = await _unitOfWork.Cars.GetListAsync(c => c.CustomerId == id && !c.IsDeleted);
            customerDto.TotalVehicles = cars.Count();
            
            var serviceRequests = await _unitOfWork.ServiceRequests.GetListAsync(s => s.CustomerId == id && !s.IsDeleted);
            customerDto.TotalServices = serviceRequests.Count();
            customerDto.CompletedServices = serviceRequests.Count(s => s.Status == Core.Enums.ServiceRequestStatus.Completed);
            customerDto.PendingServices = serviceRequests.Count(s => s.Status == Core.Enums.ServiceRequestStatus.Pending);
            
            return new SuccessDataResult<CustomerDetailDTO>(customerDto, "Müşteri başarıyla getirildi.");
        }

        public async Task<IDataResult<CustomerDetailDTO>> CreateAsync(CustomerCreateDTO dto)
        {
            var emailExists = await _unitOfWork.Customers.AnyAsync(c => c.Email == dto.Email);
            if (emailExists)
                return new ErrorDataResult<CustomerDetailDTO>("Bu email adresi zaten kayıtlı.");

            var customer = _mapper.Map<Customer>(dto);
            var createdCustomer = await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDetailDTO>(createdCustomer);
            return new SuccessDataResult<CustomerDetailDTO>(customerDto, "Müşteri başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<CustomerDetailDTO>> UpdateAsync(CustomerUpdateDTO dto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(dto.Id);

            if (customer == null)
                return new ErrorDataResult<CustomerDetailDTO>("Müşteri bulunamadı.");

            if (customer.IsDeleted)
                return new ErrorDataResult<CustomerDetailDTO>("Silinmiş müşteri güncellenemez.");

            var emailExists = await _unitOfWork.Customers.AnyAsync(c => c.Email == dto.Email && c.Id != dto.Id);
            if (emailExists)
                return new ErrorDataResult<CustomerDetailDTO>("Bu email adresi başka bir müşteri tarafından kullanılıyor.");

            // REQUIRED ALANLAR - Her zaman güncellenir
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.IsActive = dto.IsActive;
            customer.CustomerTypeId = dto.CustomerTypeId;

            // OPTIONAL ALANLAR - Sadece DTO'da geldiyse güncellenir
            if (dto.Address is not null)
                customer.Address = dto.Address;

            if (dto.City is not null)
                customer.City = dto.City;

            if (dto.Country is not null)
                customer.Country = dto.Country;

            if (dto.PostalCode is not null)
                customer.PostalCode = dto.PostalCode;

            if (dto.TaxNumber is not null)
                customer.TaxNumber = dto.TaxNumber;

            if (dto.CompanyName is not null)
                customer.CompanyName = dto.CompanyName;

            if (dto.Notes is not null)
                customer.Notes = dto.Notes;

            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDetailDTO>(customer);
            return new SuccessDataResult<CustomerDetailDTO>(customerDto, "Müşteri başarıyla güncellendi.");
        }

        public async Task<IResult> SoftDeleteAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
            {
                IResult errorResult = new ErrorResult("Müşteri bulunamadı.");
                return errorResult;
            }

            if (customer.IsDeleted)
            {
                IResult errorResult = new ErrorResult("Müşteri zaten silinmiş.");
                return errorResult;
            }

            var deleted = await _unitOfWork.Customers.DeleteAsync(id);

            if (!deleted)
            {
                IResult errorResult = new ErrorResult("Müşteri silinemedi.");
                return errorResult;
            }

            await _unitOfWork.SaveChangesAsync();
            IResult successResult = new SuccessResult("Müşteri başarıyla silindi.");
            return successResult;
        }

        public async Task<IResult> SetActiveAsync(int id, bool isActive)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
            {
                IResult errorResult = new ErrorResult("Müşteri bulunamadı.");
                return errorResult;
            }

            if (customer.IsDeleted)
            {
                IResult errorResult = new ErrorResult("Silinmiş müşteri aktif/pasif yapılamaz.");
                return errorResult;
            }

            customer.IsActive = isActive;
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var message = isActive ? "Müşteri aktif hale getirildi." : "Müşteri pasif hale getirildi.";
            IResult successResult = new SuccessResult(message);
            return successResult;
        }
    }
}