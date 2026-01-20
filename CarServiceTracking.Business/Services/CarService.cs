using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.CarDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // PlateNumber Normalize Helper
        private string NormalizePlateNumber(string plateNumber)
        {
            return plateNumber.Replace(" ", "").Replace("-", "").ToUpperInvariant();
        }

        public async Task<IDataResult<List<CarListDTO>>> GetAllAsync()
        {
            var cars = await _unitOfWork.CarRepository.GetAllWithDetailsAsync();
            var carList = cars.ToList();
            var carDtos = _mapper.Map<List<CarListDTO>>(carList);
            return new SuccessDataResult<List<CarListDTO>>(carDtos, "Araçlar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<CarListDTO>>> GetActiveAsync()
        {
            var cars = await _unitOfWork.CarRepository.GetAllWithDetailsAsync();
            var activeCars = cars.Where(c => c.IsActive).ToList();
            var carDtos = _mapper.Map<List<CarListDTO>>(activeCars);
            return new SuccessDataResult<List<CarListDTO>>(carDtos, "Aktif araçlar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<CarListItemDTO>>> GetCarListItemsAsync()
        {
            var cars = await _unitOfWork.Cars.GetListAsync(c => c.IsActive);
            var carList = cars.ToList();
            var carDtos = _mapper.Map<List<CarListItemDTO>>(carList);
            return new SuccessDataResult<List<CarListItemDTO>>(carDtos);
        }

        public async Task<IDataResult<List<CarListDTO>>> GetCarsByCustomerIdAsync(int customerId)
        {
            var cars = await _unitOfWork.CarRepository.GetCarsByCustomerIdWithDetailsAsync(customerId);
            var carList = cars.ToList();
            var carDtos = _mapper.Map<List<CarListDTO>>(carList);
            return new SuccessDataResult<List<CarListDTO>>(carDtos, "Müşteri araçları başarıyla listelendi.");
        }

        public async Task<IDataResult<CarDetailDTO>> GetByIdAsync(int id)
        {
            var car = await _unitOfWork.CarRepository.GetByIdWithDetailsAsync(id);

            if (car == null)
                return new ErrorDataResult<CarDetailDTO>("Araç bulunamadı.");

            if (car.IsDeleted)
                return new ErrorDataResult<CarDetailDTO>("Araç silinmiş.");

            var carDto = _mapper.Map<CarDetailDTO>(car);
            return new SuccessDataResult<CarDetailDTO>(carDto, "Araç başarıyla getirildi.");
        }

        public async Task<IDataResult<CarDetailDTO>> GetByPlateNumberAsync(string plateNumber)
        {
            var normalizedPlate = NormalizePlateNumber(plateNumber);
            var car = await _unitOfWork.CarRepository.GetByPlateNumberWithDetailsAsync(normalizedPlate);

            if (car == null)
                return new ErrorDataResult<CarDetailDTO>("Araç bulunamadı.");

            if (car.IsDeleted)
                return new ErrorDataResult<CarDetailDTO>("Araç silinmiş.");

            var carDto = _mapper.Map<CarDetailDTO>(car);
            return new SuccessDataResult<CarDetailDTO>(carDto, "Araç başarıyla getirildi.");
        }

        public async Task<IDataResult<CarDetailDTO>> CreateAsync(CarCreateDTO dto)
        {
            // PlateNumber normalize
            var normalizedPlate = NormalizePlateNumber(dto.PlateNumber);

            // Plate unique kontrolü
            var plateExists = await _unitOfWork.CarRepository.IsPlateExistsAsync(normalizedPlate);
            if (plateExists)
                return new ErrorDataResult<CarDetailDTO>("Bu plaka zaten kayıtlı.");

            // Customer var mı + IsDeleted değil mi
            var customerExists = await _unitOfWork.Customers.AnyAsync(c => c.Id == dto.CustomerId && !c.IsDeleted);
            if (!customerExists)
                return new ErrorDataResult<CarDetailDTO>("Müşteri bulunamadı veya silinmiş.");

            var car = _mapper.Map<Car>(dto);
            car.PlateNumber = normalizedPlate;

            var createdCar = await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.SaveChangesAsync();

            // Details ile yeniden çek
            var carWithDetails = await _unitOfWork.CarRepository.GetByIdWithDetailsAsync(createdCar.Id);
            if (carWithDetails == null)
                return new ErrorDataResult<CarDetailDTO>("Araç oluşturuldu ancak detaylar getirilemedi.");

            var carDto = _mapper.Map<CarDetailDTO>(carWithDetails);
            return new SuccessDataResult<CarDetailDTO>(carDto, "Araç başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<CarDetailDTO>> UpdateAsync(CarUpdateDTO dto)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(dto.Id);

            if (car == null)
                return new ErrorDataResult<CarDetailDTO>("Araç bulunamadı.");

            if (car.IsDeleted)
                return new ErrorDataResult<CarDetailDTO>("Silinmiş araç güncellenemez.");

            // PlateNumber normalize
            var normalizedPlate = NormalizePlateNumber(dto.PlateNumber);

            // Plate unique kontrolü (kendi id hariç)
            var plateExists = await _unitOfWork.CarRepository.IsPlateExistsAsync(normalizedPlate, dto.Id);
            if (plateExists)
                return new ErrorDataResult<CarDetailDTO>("Bu plaka başka bir araç tarafından kullanılıyor.");

            // Customer var mı + IsDeleted değil mi
            var customerExists = await _unitOfWork.Customers.AnyAsync(c => c.Id == dto.CustomerId && !c.IsDeleted);
            if (!customerExists)
                return new ErrorDataResult<CarDetailDTO>("Müşteri bulunamadı veya silinmiş.");

            // Mileage azalmasın kontrolü
            if (dto.Mileage.HasValue && car.Mileage.HasValue && dto.Mileage < car.Mileage)
                return new ErrorDataResult<CarDetailDTO>("Kilometre azaltılamaz.");

            // MANUEL PATCH MAPPING (veri kaybı yok)
            // REQUIRED
            car.PlateNumber = normalizedPlate;
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.CustomerId = dto.CustomerId;
            car.IsActive = dto.IsActive;

            // OPTIONAL
            if (dto.Color is not null)
                car.Color = dto.Color;

            if (dto.ChassisNumber is not null)
                car.ChassisNumber = dto.ChassisNumber;

            if (dto.Mileage is not null)
                car.Mileage = dto.Mileage;

            if (dto.EngineNumber is not null)
                car.EngineNumber = dto.EngineNumber;

            if (dto.Notes is not null)
                car.Notes = dto.Notes;

            car.FuelTypeId = dto.FuelTypeId;
            car.TransmissionTypeId = dto.TransmissionTypeId;
            car.CarTypeId = dto.CarTypeId;

            await _unitOfWork.Cars.UpdateAsync(car);
            await _unitOfWork.SaveChangesAsync();

            var carWithDetails = await _unitOfWork.CarRepository.GetByIdWithDetailsAsync(car.Id);
            if (carWithDetails == null)
                return new ErrorDataResult<CarDetailDTO>("Araç güncellendi ancak detaylar getirilemedi.");

            var carDto = _mapper.Map<CarDetailDTO>(carWithDetails);
            return new SuccessDataResult<CarDetailDTO>(carDto, "Araç başarıyla güncellendi.");
        }

        public async Task<IResult> SoftDeleteAsync(int id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);

            if (car == null)
                return new ErrorResult("Araç bulunamadı.");

            if (car.IsDeleted)
                return new ErrorResult("Araç zaten silinmiş.");

            var deleted = await _unitOfWork.Cars.DeleteAsync(id);

            if (!deleted)
                return new ErrorResult("Araç silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Araç başarıyla silindi.");
        }

        public async Task<IResult> SetActiveAsync(int id, bool isActive)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);

            if (car == null)
                return new ErrorResult("Araç bulunamadı.");

            if (car.IsDeleted)
                return new ErrorResult("Silinmiş araç aktif/pasif yapılamaz.");

            car.IsActive = isActive;
            await _unitOfWork.Cars.UpdateAsync(car);
            await _unitOfWork.SaveChangesAsync();

            var message = isActive ? "Araç aktif hale getirildi." : "Araç pasif hale getirildi.";
            return new SuccessResult(message);
        }
    }
}