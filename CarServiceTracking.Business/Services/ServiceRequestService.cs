using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.ServiceRequestDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // =========================
        // CREATE
        // =========================
        public async Task<IResult> CreateAsync(ServiceRequestCreateDTO dto)
        {
            // CarId, CustomerCars tablosundan gelebilir.
            // Cars tablosunda karsilik gelen kayit yoksa olustur.
            var carId = await ResolveCarIdAsync(dto.CarId, dto.CustomerId);
            if (carId == 0)
                return new ErrorResult("Araç bulunamadı.");

            var entity = _mapper.Map<ServiceRequest>(dto);
            entity.CarId = carId;
            entity.Status = ServiceRequestStatus.Pending;
            entity.CreatedAt = DateTime.Now;
            entity.PreferredDate = dto.PreferredDate;

            await _unitOfWork.ServiceRequests.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Servis talebi oluşturuldu.");
        }

        /// <summary>
        /// CustomerCar ID verilmisse, Cars tablosunda karsilik gelen kaydi bulur veya olusturur.
        /// Mantik: Gelen ID once CustomerCars'ta aranir (musteri panelinden gelir).
        /// Eger CustomerCars'ta varsa, plaka uzerinden Cars'ta eslesen kayit bulunur/olusturulur.
        /// Eger CustomerCars'ta yoksa, Cars tablosunda dogrudan aranir (admin panelinden gelir).
        /// </summary>
        private async Task<int> ResolveCarIdAsync(int carId, int customerId)
        {
            // 1. Gelen ID CustomerCars tablosunda var mi? (musteri panelinden gelen istek)
            var customerCar = await _unitOfWork.CustomerCars.GetByIdAsync(carId);
            if (customerCar != null)
            {
                // Ayni plaka + ayni musteri ile Cars tablosunda kayit var mi?
                var carByPlate = await _unitOfWork.Cars.GetAsync(
                    c => c.PlateNumber == customerCar.PlateNumber && c.CustomerId == customerId);
                if (carByPlate != null)
                    return carByPlate.Id;

                // Yoksa CustomerCar verisinden yeni Car olustur
                var brandParts = customerCar.BrandModel.Split(' ', 2);
                var newCar = new Car
                {
                    CustomerId = customerId,
                    PlateNumber = customerCar.PlateNumber,
                    Brand = brandParts.Length > 0 ? brandParts[0] : customerCar.BrandModel,
                    Model = brandParts.Length > 1 ? brandParts[1] : "",
                    Year = customerCar.Year,
                    Mileage = customerCar.Mileage,
                    Color = customerCar.Color
                };

                await _unitOfWork.Cars.AddAsync(newCar);
                await _unitOfWork.SaveChangesAsync();
                return newCar.Id;
            }

            // 2. CustomerCars'ta yok -> dogrudan Cars tablosunda ara (admin panelinden gelen istek)
            var existingCar = await _unitOfWork.Cars.GetByIdAsync(carId);
            if (existingCar != null)
                return existingCar.Id;

            return 0;
        }

        // =========================
        // GET ALL (ADMIN)
        // =========================
        public async Task<IDataResult<List<ServiceRequestListDTO>>> GetAllAsync()
        {
            var entities = await _unitOfWork.ServiceRequests.GetAllAsync();

            var ordered = entities
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            var dtoList = _mapper.Map<List<ServiceRequestListDTO>>(ordered);

            // 🔥 Araç adını manuel doldur
            foreach (var dto in dtoList)
            {
                var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarId);
                dto.CarName = car != null ? $"{car.Brand} {car.Model}" : "-";
            }

            return new SuccessDataResult<List<ServiceRequestListDTO>>(dtoList);
        }

        // =========================
        // GET BY CUSTOMER
        // =========================
        public async Task<IDataResult<List<ServiceRequestListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            var entities = await _unitOfWork.ServiceRequests
                .GetListAsync(x => x.CustomerId == customerId);

            var ordered = entities
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            var dtoList = _mapper.Map<List<ServiceRequestListDTO>>(ordered);

            // 🔥 Araç adını manuel doldur
            foreach (var dto in dtoList)
            {
                var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarId);
                dto.CarName = car != null ? $"{car.Brand} {car.Model}" : "-";
            }

            return new SuccessDataResult<List<ServiceRequestListDTO>>(dtoList);
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<IDataResult<ServiceRequestDetailDTO>> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ServiceRequests.GetByIdAsync(id);

            if (entity == null)
                return new ErrorDataResult<ServiceRequestDetailDTO>("Servis talebi bulunamadı.");

            var dto = _mapper.Map<ServiceRequestDetailDTO>(entity);

            var car = await _unitOfWork.Cars.GetByIdAsync(entity.CarId);
            dto.CarName = car != null ? $"{car.Brand} {car.Model}" : "-";

            return new SuccessDataResult<ServiceRequestDetailDTO>(dto);
        }

        // =========================
        // UPDATE (Customer Edit)
        // =========================
        public async Task<IResult> UpdateAsync(int id, ServiceRequestUpdateDTO dto)
        {
            var entity = await _unitOfWork.ServiceRequests.GetByIdAsync(id);

            if (entity == null)
                return new ErrorResult("Servis talebi bulunamadı.");

            if (entity.Status != ServiceRequestStatus.Pending)
                return new ErrorResult("Sadece beklemede olan talepler düzenlenebilir.");

            // CarId, CustomerCars tablosundan gelebilir - cozumle
            var carId = await ResolveCarIdAsync(dto.CarId, entity.CustomerId);
            if (carId == 0)
                return new ErrorResult("Araç bulunamadı.");

            entity.CarId = carId;
            entity.ProblemDescription = dto.ProblemDescription;
            entity.PreferredDate = dto.PreferredDate;
            entity.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Servis talebi güncellendi.");
        }

        // =========================
        // UPDATE STATUS
        // =========================
        public async Task<IResult> UpdateStatusAsync(int id, int status, decimal? servicePrice, string? adminNote)
        {
            var entity = await _unitOfWork.ServiceRequests.GetByIdAsync(id);

            if (entity == null)
                return new ErrorResult("Servis talebi bulunamadı.");

            entity.Status = (ServiceRequestStatus)status;
            entity.ServicePrice = servicePrice;
            entity.AdminNote = adminNote;
            entity.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Durum başarıyla güncellendi.");
        }

        // =========================
        // DELETE
        // =========================
        public async Task<IResult> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ServiceRequests.GetByIdAsync(id);

            if (entity == null)
                return new ErrorResult("Servis talebi bulunamadı.");

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Servis talebi başarıyla silindi.");
        }
    }
}
