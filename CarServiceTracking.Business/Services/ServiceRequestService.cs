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
            var entity = _mapper.Map<ServiceRequest>(dto);

            entity.Status = ServiceRequestStatus.Pending;
            entity.CreatedAt = DateTime.Now;

            //  PreferredDate zaten DateTime? → manuel parse GEREKMİYOR
            entity.PreferredDate = dto.PreferredDate;

            await _unitOfWork.ServiceRequests.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Servis talebi oluşturuldu.");
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
