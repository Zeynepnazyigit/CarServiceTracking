using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.RentalDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class RentalService : IRentalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RentalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region RentalVehicle Methods

        public async Task<IDataResult<List<RentalVehicleListDTO>>> GetAllVehiclesAsync()
        {
            var vehicles = await _unitOfWork.RentalVehicles.GetAllAsync();
            var vehicleDtos = new List<RentalVehicleListDTO>();

            foreach (var vehicle in vehicles.OrderBy(x => x.Brand).ThenBy(x => x.Model))
            {
                var dto = _mapper.Map<RentalVehicleListDTO>(vehicle);
                dto.DisplayName = vehicle.DisplayName;

                var agreements = await _unitOfWork.RentalAgreements.GetListAsync(x => x.RentalVehicleId == vehicle.Id);
                dto.ActiveRentals = agreements.Count(x => x.Status == RentalStatus.Active);

                vehicleDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalVehicleListDTO>>(vehicleDtos, "Kiralık araçlar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<RentalVehicleListDTO>>> GetAvailableVehiclesAsync()
        {
            var vehicles = await _unitOfWork.RentalVehicles.GetListAsync(x => x.IsAvailable);
            var vehicleDtos = new List<RentalVehicleListDTO>();

            foreach (var vehicle in vehicles.OrderBy(x => x.DailyRate))
            {
                var dto = _mapper.Map<RentalVehicleListDTO>(vehicle);
                dto.DisplayName = vehicle.DisplayName;

                var agreements = await _unitOfWork.RentalAgreements.GetListAsync(x => x.RentalVehicleId == vehicle.Id);
                dto.ActiveRentals = agreements.Count(x => x.Status == RentalStatus.Active);

                vehicleDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalVehicleListDTO>>(vehicleDtos, "Müsait kiralık araçlar başarıyla listelendi.");
        }

        public async Task<IDataResult<RentalVehicleDetailDTO>> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(id);

            if (vehicle == null)
                return new ErrorDataResult<RentalVehicleDetailDTO>("Kiralık araç bulunamadı.");

            var dto = _mapper.Map<RentalVehicleDetailDTO>(vehicle);
            dto.DisplayName = vehicle.DisplayName;

            return new SuccessDataResult<RentalVehicleDetailDTO>(dto, "Kiralık araç başarıyla getirildi.");
        }

        public async Task<IDataResult<RentalVehicleDetailDTO>> CreateVehicleAsync(RentalVehicleCreateDTO dto)
        {
            var existingVehicle = await _unitOfWork.RentalVehicles.GetAsync(x => x.PlateNumber == dto.PlateNumber);
            if (existingVehicle != null)
                return new ErrorDataResult<RentalVehicleDetailDTO>("Bu plaka numarası zaten kayıtlı.");

            var vehicle = _mapper.Map<RentalVehicle>(dto);

            var createdVehicle = await _unitOfWork.RentalVehicles.AddAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetVehicleByIdAsync(createdVehicle.Id);
            return new SuccessDataResult<RentalVehicleDetailDTO>(result.Data, "Kiralık araç başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<RentalVehicleDetailDTO>> UpdateVehicleAsync(RentalVehicleUpdateDTO dto)
        {
            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(dto.Id);

            if (vehicle == null)
                return new ErrorDataResult<RentalVehicleDetailDTO>("Kiralık araç bulunamadı.");

            var existingVehicle = await _unitOfWork.RentalVehicles.GetAsync(x => x.PlateNumber == dto.PlateNumber && x.Id != dto.Id);
            if (existingVehicle != null)
                return new ErrorDataResult<RentalVehicleDetailDTO>("Bu plaka numarası başka bir araç tarafından kullanılıyor.");

            _mapper.Map(dto, vehicle);
            vehicle.IsAvailable = dto.IsAvailable;
            vehicle.ModifiedDate = DateTime.Now;

            await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetVehicleByIdAsync(vehicle.Id);
            return new SuccessDataResult<RentalVehicleDetailDTO>(result.Data, "Kiralık araç başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteVehicleAsync(int id)
        {
            var success = await _unitOfWork.RentalVehicles.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Kiralık araç silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Kiralık araç başarıyla silindi.");
        }

        #endregion

        #region RentalAgreement Methods

        public async Task<IDataResult<List<RentalAgreementListDTO>>> GetAllAgreementsAsync()
        {
            var agreements = await _unitOfWork.RentalAgreements.GetAllAsync();
            var agreementDtos = new List<RentalAgreementListDTO>();

            foreach (var agreement in agreements.OrderByDescending(x => x.StartDate))
            {
                var dto = _mapper.Map<RentalAgreementListDTO>(agreement);

                var customer = await _unitOfWork.Customers.GetByIdAsync(agreement.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
                dto.VehicleInfo = vehicle?.DisplayName ?? "Bilinmiyor";

                agreementDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalAgreementListDTO>>(agreementDtos, "Kiralama sözleşmeleri başarıyla listelendi.");
        }

        public async Task<IDataResult<List<RentalAgreementListDTO>>> GetActiveAgreementsAsync()
        {
            var agreements = await _unitOfWork.RentalAgreements.GetListAsync(x => x.Status == RentalStatus.Active);
            var agreementDtos = new List<RentalAgreementListDTO>();

            foreach (var agreement in agreements.OrderBy(x => x.EndDate))
            {
                var dto = _mapper.Map<RentalAgreementListDTO>(agreement);

                var customer = await _unitOfWork.Customers.GetByIdAsync(agreement.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
                dto.VehicleInfo = vehicle?.DisplayName ?? "Bilinmiyor";

                agreementDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalAgreementListDTO>>(agreementDtos, "Aktif kiralama sözleşmeleri başarıyla listelendi.");
        }

        public async Task<IDataResult<List<RentalAgreementListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            var agreements = await _unitOfWork.RentalAgreements.GetListAsync(x => x.CustomerId == customerId);
            var agreementDtos = new List<RentalAgreementListDTO>();

            foreach (var agreement in agreements.OrderByDescending(x => x.StartDate))
            {
                var dto = _mapper.Map<RentalAgreementListDTO>(agreement);

                var customer = await _unitOfWork.Customers.GetByIdAsync(agreement.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
                dto.VehicleInfo = vehicle?.DisplayName ?? "Bilinmiyor";

                agreementDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalAgreementListDTO>>(agreementDtos, "Kiralama sözleşmeleri başarıyla listelendi.");
        }

        public async Task<IDataResult<List<RentalAgreementListDTO>>> GetOverdueAgreementsAsync()
        {
            var agreements = await _unitOfWork.RentalAgreements.GetListAsync(x => 
                x.Status == RentalStatus.Active && 
                x.EndDate < DateTime.Now);

            var agreementDtos = new List<RentalAgreementListDTO>();

            foreach (var agreement in agreements.OrderBy(x => x.EndDate))
            {
                var dto = _mapper.Map<RentalAgreementListDTO>(agreement);

                var customer = await _unitOfWork.Customers.GetByIdAsync(agreement.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
                dto.VehicleInfo = vehicle?.DisplayName ?? "Bilinmiyor";

                agreementDtos.Add(dto);
            }

            return new SuccessDataResult<List<RentalAgreementListDTO>>(agreementDtos, "Vadesi geçmiş kiralamalar başarıyla listelendi.");
        }

        public async Task<IDataResult<RentalAgreementDetailDTO>> GetAgreementByIdAsync(int id)
        {
            var agreement = await _unitOfWork.RentalAgreements.GetByIdAsync(id);

            if (agreement == null)
                return new ErrorDataResult<RentalAgreementDetailDTO>("Kiralama sözleşmesi bulunamadı.");

            var dto = _mapper.Map<RentalAgreementDetailDTO>(agreement);

            var customer = await _unitOfWork.Customers.GetByIdAsync(agreement.CustomerId);
            dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
            dto.CustomerPhone = customer?.Phone ?? "Bilinmiyor";

            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
            dto.VehicleInfo = vehicle?.DisplayName ?? "Bilinmiyor";

            return new SuccessDataResult<RentalAgreementDetailDTO>(dto, "Kiralama sözleşmesi başarıyla getirildi.");
        }

        public async Task<IDataResult<RentalAgreementDetailDTO>> CreateAgreementAsync(RentalAgreementCreateDTO dto)
        {
            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(dto.RentalVehicleId);
            if (vehicle == null)
                return new ErrorDataResult<RentalAgreementDetailDTO>("Kiralık araç bulunamadı.");

            if (!vehicle.IsAvailable)
                return new ErrorDataResult<RentalAgreementDetailDTO>("Bu araç şu anda müsait değil.");

            var agreement = _mapper.Map<RentalAgreement>(dto);
            agreement.AgreementNumber = await GenerateAgreementNumberAsync();
            agreement.Status = RentalStatus.Active;

            // 12 Şubat → 13 Şubat = 1 gün (başlangıç/bitiş dahil tek gün); aynı gün en az 1 gün
            var rentalDays = Math.Max(1, (dto.EndDate.Date - dto.StartDate.Date).Days);
            agreement.TotalDays = rentalDays;
            agreement.DailyRate = vehicle.DailyRate;
            agreement.TotalAmount = rentalDays * vehicle.DailyRate;

            vehicle.IsAvailable = false;
            await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);

            var createdAgreement = await _unitOfWork.RentalAgreements.AddAsync(agreement);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetAgreementByIdAsync(createdAgreement.Id);
            return new SuccessDataResult<RentalAgreementDetailDTO>(result.Data, "Kiralama sözleşmesi başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<RentalAgreementDetailDTO>>
CreateRentalWithVehicleLockAsync(RentalAgreementCreateDTO dto)
        {
            // 1) Aracı çek
            var vehicle = await _unitOfWork.RentalVehicles
                .GetByIdAsync(dto.RentalVehicleId);

            if (vehicle == null)
                return new ErrorDataResult<RentalAgreementDetailDTO>(
                    "Kiralık araç bulunamadı.");

            if (!vehicle.IsAvailable)
                return new ErrorDataResult<RentalAgreementDetailDTO>(
                    "Bu araç şu anda müsait değil.");

            try
            {
                // 2) Explicit transaction başlat
                await _unitOfWork.BeginTransactionAsync();

                // 3) Aracı kilitle
                vehicle.IsAvailable = false;
                await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);

                // 4) Sözleşmeyi hazırla
                var agreement = _mapper.Map<RentalAgreement>(dto);
                agreement.AgreementNumber = await GenerateAgreementNumberAsync();
                agreement.Status = RentalStatus.Active;

                var rentalDays = Math.Max(1, (dto.EndDate.Date - dto.StartDate.Date).Days);
                agreement.TotalDays = rentalDays;
                agreement.DailyRate = vehicle.DailyRate;
                agreement.TotalAmount = rentalDays * vehicle.DailyRate;

                // 5) Sözleşmeyi ekle
                var createdAgreement =
                    await _unitOfWork.RentalAgreements.AddAsync(agreement);

                // 6) Kaydet ve commit (atomic)
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                var result = await GetAgreementByIdAsync(createdAgreement.Id);
                return new SuccessDataResult<RentalAgreementDetailDTO>(
                    result.Data,
                    "Kiralama başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                // Transaction rollback: hem araç hem sözleşme geri alınır
                await _unitOfWork.RollbackAsync();

                return new ErrorDataResult<RentalAgreementDetailDTO>(
                    "Kiralama sırasında hata oluştu: " + ex.Message);
            }
        }


        public async Task<IDataResult<RentalAgreementDetailDTO>> UpdateAgreementAsync(RentalAgreementUpdateDTO dto)
        {
            var agreement = await _unitOfWork.RentalAgreements.GetByIdAsync(dto.Id);

            if (agreement == null)
                return new ErrorDataResult<RentalAgreementDetailDTO>("Kiralama sözleşmesi bulunamadı.");

            var oldEndDate = agreement.EndDate;
            _mapper.Map(dto, agreement);

            if (oldEndDate != dto.EndDate)
            {
                var rentalDays = Math.Max(1, (dto.EndDate.Date - agreement.StartDate.Date).Days);
                agreement.TotalDays = rentalDays;
                agreement.TotalAmount = rentalDays * agreement.DailyRate;
            }

            if (dto.ActualReturnDate.HasValue)
            {
                var actualDays = Math.Max(1, (dto.ActualReturnDate.Value.Date - agreement.StartDate.Date).Days);
                if (actualDays > agreement.TotalDays)
                {
                    var lateDays = actualDays - agreement.TotalDays;
                    agreement.LateFee = lateDays * agreement.DailyRate * 1.5m;
                    agreement.TotalAmount += agreement.LateFee.Value;
                }
            }

            agreement.ModifiedDate = DateTime.Now;

            await _unitOfWork.RentalAgreements.UpdateAsync(agreement);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetAgreementByIdAsync(agreement.Id);
            return new SuccessDataResult<RentalAgreementDetailDTO>(result.Data, "Kiralama sözleşmesi başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAgreementAsync(int id)
        {
            var agreement = await _unitOfWork.RentalAgreements.GetByIdAsync(id);
            if (agreement == null)
                return new ErrorResult("Kiralama sözleşmesi bulunamadı.");

            var vehicleId = agreement.RentalVehicleId;
            var success = await _unitOfWork.RentalAgreements.DeleteAsync(id);
            if (!success)
                return new ErrorResult("Kiralama sözleşmesi silinemedi.");

            // Silinen sözleşmenin aracını tekrar müsait yap (Geçici Araçlar listesinde görünsün)
            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(vehicleId);
            if (vehicle != null)
            {
                vehicle.IsAvailable = true;
                await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);
            }

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Kiralama sözleşmesi başarıyla silindi.");
        }

        public async Task<IResult> CompleteRentalAsync(int agreementId, int endMileage, DateTime returnDate)
        {
            var agreement = await _unitOfWork.RentalAgreements.GetByIdAsync(agreementId);

            if (agreement == null)
                return new ErrorResult("Kiralama sözleşmesi bulunamadı.");

            if (agreement.Status != RentalStatus.Active)
                return new ErrorResult("Bu kiralama aktif değil.");

            agreement.EndMileage = endMileage;
            agreement.ActualReturnDate = returnDate;
            agreement.Status = RentalStatus.Completed;

            // Depozito teslim sonrası iade edilmiş sayılır (clean code: tek sorumluluk)
            agreement.DepositRefunded = true;
            agreement.DepositRefundedDate = DateTime.Now;

            var actualDays = Math.Max(1, (returnDate.Date - agreement.StartDate.Date).Days);
            if (actualDays > agreement.TotalDays)
            {
                var lateDays = actualDays - agreement.TotalDays;
                agreement.LateFee = lateDays * agreement.DailyRate * 1.5m;
                agreement.TotalAmount += agreement.LateFee.Value;
            }

            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(agreement.RentalVehicleId);
            if (vehicle != null)
            {
                vehicle.IsAvailable = true;
                vehicle.Mileage = endMileage;
                await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);
            }

            agreement.ModifiedDate = DateTime.Now;
            await _unitOfWork.RentalAgreements.UpdateAsync(agreement);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Kiralama başarıyla tamamlandı.");
        }

        #endregion

        #region Sync Methods

        public async Task<IResult> SyncVehicleAvailabilityAsync()
        {
            var allVehicles = await _unitOfWork.RentalVehicles.GetAllAsync();
            var activeAgreements = await _unitOfWork.RentalAgreements
                .GetListAsync(x => x.Status == RentalStatus.Active);

            var activeVehicleIds = activeAgreements
                .Select(a => a.RentalVehicleId)
                .Distinct()
                .ToHashSet();

            int fixedCount = 0;

            foreach (var vehicle in allVehicles)
            {
                bool shouldBeAvailable = !activeVehicleIds.Contains(vehicle.Id);

                if (vehicle.IsAvailable != shouldBeAvailable)
                {
                    vehicle.IsAvailable = shouldBeAvailable;
                    await _unitOfWork.RentalVehicles.UpdateAsync(vehicle);
                    fixedCount++;
                }
            }

            return new SuccessResult(
                $"Senkronizasyon tamamlandi. {fixedCount} aracin durumu duzeltildi.");
        }

        public async Task<IResult> SetAllVehiclesAvailableAsync()
        {
            var vehicles = (await _unitOfWork.RentalVehicles.GetAllAsync()).ToList();
            foreach (var v in vehicles)
                v.IsAvailable = true;
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult($"Tüm araçlar müsait yapıldı. ({vehicles.Count} araç)");
        }

        #endregion

        #region Helper Methods

        private Task<string> GenerateAgreementNumberAsync()
        {
            // Tarih + milisaniye bazli benzersiz numara uret
            // Soft-deleted kayitlarla cakisma sorununu ortadan kaldirir
            var now = DateTime.Now;
            return Task.FromResult($"RNT{now:yyyyMMddHHmmssfff}");
        }

        #endregion
    }
}
