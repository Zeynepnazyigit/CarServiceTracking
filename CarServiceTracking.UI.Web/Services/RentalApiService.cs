using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.RentalApiModels;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Services
{
    public class RentalApiService
    {
        private readonly HttpClient _client;

        public RentalApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        #region Rental Vehicles

        public async Task<List<RentalVehicleListVM>> GetAllVehiclesAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalVehicleListApiModel>>>("api/Rentals/vehicles");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalVehicleListVM>();

            return response.Data.Select(dto => new RentalVehicleListVM
            {
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                FuelType = dto.FuelType ?? "Belirtilmemiş",
                TransmissionType = dto.TransmissionType ?? "Belirtilmemiş",
                Color = dto.Color,
                DailyRate = dto.DailyRate,
                IsAvailable = dto.IsAvailable,
                ImageUrl = dto.ImageUrl
            }).ToList();
        }

        public async Task<List<RentalVehicleListVM>> GetAvailableVehiclesAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalVehicleListApiModel>>>("api/Rentals/vehicles/available");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalVehicleListVM>();

            return response.Data.Select(dto => new RentalVehicleListVM
            {
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                FuelType = dto.FuelType ?? "Belirtilmemiş",
                TransmissionType = dto.TransmissionType ?? "Belirtilmemiş",
                Color = dto.Color,
                DailyRate = dto.DailyRate,
                IsAvailable = dto.IsAvailable,
                ImageUrl = dto.ImageUrl
            }).ToList();
        }

        public async Task<List<RentalVehicleDropdownVM>> GetVehiclesForDropdownAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalVehicleListApiModel>>>("api/Rentals/vehicles/available");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalVehicleDropdownVM>();

            return response.Data.Select(dto => new RentalVehicleDropdownVM
            {
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                DailyRate = dto.DailyRate
            }).ToList();
        }

        public async Task<RentalVehicleEditVM?> GetVehicleByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>($"api/Rentals/vehicles/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO has FuelType/TransmissionType
            return new RentalVehicleEditVM
            {
                Id = response.Data.Id,
                PlateNumber = response.Data.PlateNumber,
                Brand = response.Data.Brand,
                Model = response.Data.Model,
                Year = response.Data.Year,
                FuelType = response.Data.FuelType ?? string.Empty,
                TransmissionType = response.Data.TransmissionType ?? string.Empty,
                DailyRate = response.Data.DailyRate,
                IsAvailable = response.Data.IsAvailable,
                Features = response.Data.Notes // Notes → Features
            };
        }

        public async Task<RentalVehicleDetailApiModel?> GetVehicleDetailAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>($"api/Rentals/vehicles/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            return response.Data;
        }

        public async Task<(bool Success, string Message)> CreateVehicleAsync(RentalVehicleCreateVM vm)
        {
            // VM → DTO: Features not in CreateDTO
            var dto = new RentalVehicleCreateApiModel
            {
                PlateNumber = vm.PlateNumber,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                DailyRate = vm.DailyRate,
                IsAvailable = vm.IsAvailable
            };

            var response = await _client.PostAsJsonAsync("api/Rentals/vehicles", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Kiralık araç oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateVehicleAsync(RentalVehicleEditVM vm)
        {
            var dto = new RentalVehicleUpdateApiModel
            {
                Id = vm.Id,
                PlateNumber = vm.PlateNumber,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                DailyRate = vm.DailyRate,
                IsAvailable = vm.IsAvailable
            };

            var response = await _client.PutAsJsonAsync($"api/Rentals/vehicles/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Kiralık araç güncellenemedi");
        }

        public async Task<(bool Success, string Message)> DeleteVehicleAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Rentals/vehicles/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Kiralık araç silinemedi");
        }

        #endregion

        #region Rental Agreements

        public async Task<List<RentalAgreementListVM>> GetAllAgreementsAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalAgreementListApiModel>>>("api/Rentals/agreements");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalAgreementListVM>();

            // DTO → VM: TotalCost → TotalAmount, no Mileage/DailyRate/Deposit in ListDTO
            return response.Data.Select(dto => new RentalAgreementListVM
            {
                Id = dto.Id,
                AgreementNumber = dto.AgreementNumber,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                RentalVehicleId = dto.RentalVehicleId,
                VehicleInfo = dto.VehicleInfo,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StartMileage = 0, // Not in ListDTO
                EndMileage = null,
                DailyRate = 0,
                TotalAmount = dto.TotalCost,
                DepositAmount = 0,
                Status = dto.Status.ToString()
            }).ToList();
        }

        public async Task<List<RentalAgreementListVM>> GetActiveAgreementsAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalAgreementListApiModel>>>("api/Rentals/agreements/active");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalAgreementListVM>();

            return response.Data.Select(dto => new RentalAgreementListVM
            {
                Id = dto.Id,
                AgreementNumber = dto.AgreementNumber,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                RentalVehicleId = dto.RentalVehicleId,
                VehicleInfo = dto.VehicleInfo,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StartMileage = 0,
                EndMileage = null,
                DailyRate = 0,
                TotalAmount = dto.TotalCost,
                DepositAmount = 0,
                Status = dto.Status.ToString()
            }).ToList();
        }

        public async Task<List<RentalAgreementListVM>> GetOverdueAgreementsAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalAgreementListApiModel>>>("api/Rentals/agreements/overdue");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalAgreementListVM>();

            return response.Data.Select(dto => new RentalAgreementListVM
            {
                Id = dto.Id,
                AgreementNumber = dto.AgreementNumber,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                RentalVehicleId = dto.RentalVehicleId,
                VehicleInfo = dto.VehicleInfo,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StartMileage = 0,
                EndMileage = null,
                DailyRate = 0,
                TotalAmount = dto.TotalCost,
                DepositAmount = 0,
                Status = dto.Status.ToString()
            }).ToList();
        }

        public async Task<List<RentalAgreementListVM>> GetAgreementsByCustomerIdAsync(int customerId)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalAgreementListApiModel>>>($"api/Rentals/agreements/customer/{customerId}");
            if (response == null || !response.Success || response.Data == null)
                return new List<RentalAgreementListVM>();

            return response.Data.Select(dto => new RentalAgreementListVM
            {
                Id = dto.Id,
                AgreementNumber = dto.AgreementNumber,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                RentalVehicleId = dto.RentalVehicleId,
                VehicleInfo = dto.VehicleInfo,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StartMileage = 0,
                EndMileage = null,
                DailyRate = 0,
                TotalAmount = dto.TotalCost,
                DepositAmount = 0,
                Status = dto.Status.ToString()
            }).ToList();
        }

        public async Task<RentalAgreementEditVM?> GetAgreementByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<RentalAgreementDetailApiModel>>($"api/Rentals/agreements/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO has all fields including TotalCost → TotalAmount, DepositAmount → Deposit
            return new RentalAgreementEditVM
            {
                Id = response.Data.Id,
                AgreementNumber = response.Data.AgreementNumber,
                CustomerId = response.Data.CustomerId,
                RentalVehicleId = response.Data.RentalVehicleId,
                StartDate = response.Data.StartDate,
                EndDate = response.Data.EndDate,
                StartMileage = response.Data.StartMileage,
                EndMileage = response.Data.EndMileage,
                DailyRate = response.Data.DailyRate,
                TotalAmount = response.Data.TotalCost,
                DepositAmount = response.Data.DepositAmount,
                Status = response.Data.Status.ToString(),
                Notes = response.Data.Notes
            };
        }

        public async Task<(bool Success, string Message)> CreateAgreementAsync(RentalAgreementCreateVM vm)
        {
            // VM → DTO: TotalAmount/DailyRate/AgreementNumber not in CreateDTO
            var dto = new RentalAgreementCreateApiModel
            {
                CustomerId = vm.CustomerId,
                RentalVehicleId = vm.RentalVehicleId,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                StartMileage = vm.StartMileage,
                DepositAmount = vm.DepositAmount,
                Notes = vm.Notes
            };

            var response = await _client.PostAsJsonAsync("api/Rentals/agreements", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<RentalAgreementDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Sözleşme oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateAgreementAsync(RentalAgreementEditVM vm)
        {
            // UpdateDTO: Limited fields
            if (!Enum.TryParse<Enums.RentalStatus>(vm.Status, out var status))
                status = Enums.RentalStatus.Active;

            var dto = new RentalAgreementUpdateApiModel
            {
                Id = vm.Id,
                EndDate = vm.EndDate,
                DepositAmount = vm.DepositAmount,
                Status = status,
                EndMileage = vm.EndMileage,
                Notes = vm.Notes
            };

            var response = await _client.PutAsJsonAsync($"api/Rentals/agreements/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<RentalAgreementDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Sözleşme güncellenemedi");
        }

        public async Task<(bool Success, string Message)> CompleteAgreementAsync(int id, int endMileage, DateTime returnDate)
        {
            var dto = new { EndMileage = endMileage, ReturnDate = returnDate };
            var response = await _client.PostAsJsonAsync($"api/Rentals/agreements/{id}/complete", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Sözleşme tamamlanamadı");
        }

        public async Task<(bool Success, string Message)> DeleteAgreementAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Rentals/agreements/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Sözleşme silinemedi");
        }

        #endregion

        #region Customer-specific Methods

        /// <summary>
        /// Müşteriye özel kiralama listesi
        /// </summary>
        public async Task<List<CustomerRentalListVM>?> GetCustomerRentalsAsync(int customerId)
        {
            var agreements = await GetAgreementsByCustomerIdAsync(customerId);
            if (agreements == null || !agreements.Any())
                return new List<CustomerRentalListVM>();

            return agreements.Select(a => new CustomerRentalListVM
            {
                Id = a.Id,
                AgreementNumber = a.AgreementNumber,
                VehicleInfo = a.VehicleInfo,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                TotalAmount = a.TotalAmount,
                Status = a.Status
            }).ToList();
        }

        /// <summary>
        /// Kiralama detayı
        /// </summary>
        public async Task<RentalDetailVM?> GetRentalDetailAsync(int id)
        {
            var agreement = await GetAgreementByIdAsync(id);
            if (agreement == null)
                return null;

            return new RentalDetailVM
            {
                Id = agreement.Id,
                AgreementNumber = agreement.AgreementNumber,
                CustomerId = agreement.CustomerId,
                CustomerName = "", // API'den gelmiyor
                RentalVehicleId = agreement.RentalVehicleId,
                VehicleInfo = "", // API'den gelmiyor
                StartDate = agreement.StartDate,
                EndDate = agreement.EndDate,
                StartMileage = agreement.StartMileage,
                EndMileage = agreement.EndMileage,
                DailyRate = agreement.DailyRate,
                TotalAmount = agreement.TotalAmount,
                DepositAmount = agreement.DepositAmount,
                Status = agreement.Status,
                Notes = agreement.Notes
            };
        }

        /// <summary>
        /// Kiralama oluştur
        /// </summary>
        public async Task<(bool Success, string Message)> CreateRentalAsync(RentalCreateVM vm)
        {
            var createDto = new RentalAgreementCreateVM
            {
                CustomerId = vm.CustomerId,
                RentalVehicleId = vm.VehicleId,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                StartMileage = vm.StartMileage ?? 0,
                DepositAmount = vm.DepositAmount,
                Notes = vm.Notes
            };

            return await CreateAgreementAsync(createDto);
        }

        #endregion
    }
}
