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
            try
            {
                var response = await _client.GetAsync("api/Rentals/vehicles/available");
                if (!response.IsSuccessStatusCode)
                    return new List<RentalVehicleListVM>();
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<List<RentalVehicleListApiModel>>>();
                if (data == null || !data.Success || data.Data == null)
                    return new List<RentalVehicleListVM>();
                return data.Data.Select(dto => new RentalVehicleListVM
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
            catch
            {
                return new List<RentalVehicleListVM>();
            }
        }

        public async Task<List<RentalVehicleDropdownVM>> GetVehiclesForDropdownAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/Rentals/vehicles/available");
                if (!response.IsSuccessStatusCode)
                    return new List<RentalVehicleDropdownVM>();
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<List<RentalVehicleListApiModel>>>();
                if (data == null || !data.Success || data.Data == null)
                    return new List<RentalVehicleDropdownVM>();

                return data.Data.Select(dto => new RentalVehicleDropdownVM
                {
                    Id = dto.Id,
                    PlateNumber = dto.PlateNumber,
                    Brand = dto.Brand,
                    Model = dto.Model,
                    Year = dto.Year,
                    DailyRate = dto.DailyRate
                }).ToList();
            }
            catch
            {
                return new List<RentalVehicleDropdownVM>();
            }
        }

        public async Task<RentalVehicleEditVM?> GetVehicleByIdAsync(int id)
        {
            try
            {
                var httpResponse = await _client.GetAsync($"api/Rentals/vehicles/{id}");
                if (!httpResponse.IsSuccessStatusCode)
                    return null;
                var response = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>();
                if (response == null || !response.Success || response.Data == null)
                    return null;
                var data = response.Data;
                return new RentalVehicleEditVM
                {
                    Id = data.Id,
                    PlateNumber = data.PlateNumber,
                    Brand = data.Brand,
                    Model = data.Model,
                    Year = data.Year,
                    FuelType = data.FuelType ?? string.Empty,
                    TransmissionType = data.TransmissionType ?? string.Empty,
                    Color = data.Color ?? string.Empty,
                    Mileage = data.Mileage,
                    DailyRate = data.DailyRate,
                    IsAvailable = data.IsAvailable,
                    Features = data.Notes
                };
            }
            catch
            {
                return null;
            }
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
                Color = vm.Color ?? string.Empty,
                Mileage = vm.Mileage ?? 0,
                FuelType = vm.FuelType ?? string.Empty,
                TransmissionType = vm.TransmissionType ?? string.Empty,
                DailyRate = vm.DailyRate,
                IsAvailable = vm.IsAvailable,
                Notes = vm.Features
            };

            var response = await _client.PutAsJsonAsync($"api/Rentals/vehicles/{vm.Id}", dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                var errorMessage = TryGetMessageFromJson(errorBody) ?? response.ReasonPhrase ?? "Kiralık araç güncellenemedi.";
                return (false, errorMessage);
            }

            // 2xx = başarılı; body farklı formatta gelse bile güncelleme yapıldı kabul et
            try
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<RentalVehicleDetailApiModel>>();
                if (result != null && result.Success)
                    return (true, result.Message ?? "Kiralık araç güncellendi.");
            }
            catch { }

            return (true, "Kiralık araç güncellendi.");
        }

        public async Task<(bool Success, string Message)> SetAllVehiclesAvailableAsync()
        {
            var response = await _client.PostAsync("api/Rentals/vehicles/set-all-available", null);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return (false, TryGetMessageFromJson(body) ?? "İşlem başarısız.");
            }
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            return (result != null && result.Success, result?.Message ?? "Tüm araçlar müsait yapıldı.");
        }

        private static string? TryGetMessageFromJson(string json)
        {
            try
            {
                var doc = System.Text.Json.JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("message", out var m))
                    return m.GetString();
                if (doc.RootElement.TryGetProperty("Message", out var M))
                    return M.GetString();
            }
            catch { }
            return null;
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
                Status = dto.Status.ToString() // ✅ FIX
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
                Status = dto.Status.ToString() // ✅ FIX
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
                Status = dto.Status.ToString() // ✅ FIX
            }).ToList();
        }

        public async Task<List<RentalAgreementListVM>> GetAgreementsByCustomerIdAsync(int customerId)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<RentalAgreementListApiModel>>>(
                $"api/Rentals/agreements/customer/{customerId}");

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
                Status = dto.Status.ToString() // ✅ FIX
            }).ToList();
        }

        public async Task<RentalAgreementEditVM?> GetAgreementByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<RentalAgreementDetailApiModel>>($"api/Rentals/agreements/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            return new RentalAgreementEditVM
            {
                Id = response.Data.Id,
                AgreementNumber = response.Data.AgreementNumber,
                CustomerId = response.Data.CustomerId,
                CustomerName = response.Data.CustomerName,
                RentalVehicleId = response.Data.RentalVehicleId,
                VehicleInfo = response.Data.VehicleInfo,
                StartDate = response.Data.StartDate,
                EndDate = response.Data.EndDate,
                StartMileage = response.Data.StartMileage,
                EndMileage = response.Data.EndMileage,
                DailyRate = response.Data.DailyRate,
                TotalAmount = response.Data.TotalCost,
                DepositAmount = response.Data.DepositAmount,
                DepositRefunded = response.Data.DepositRefunded,
                DepositRefundedDate = response.Data.DepositRefundedDate,
                Status = response.Data.Status.ToString(),
                Notes = response.Data.Notes
            };
        }

        public async Task<(bool Success, string Message)> CreateAgreementAsync(RentalAgreementCreateVM vm)
        {
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

        public async Task<List<CustomerRentalListVM>> GetCustomerRentalsAsync(int customerId)
        {
            var agreements = await GetAgreementsByCustomerIdAsync(customerId);
            if (agreements == null || agreements.Count == 0)
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
            })
            .OrderByDescending(x => x.StartDate)
            .ToList();
        }

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
                CustomerName = "",
                RentalVehicleId = agreement.RentalVehicleId,
                VehicleInfo = "",
                StartDate = agreement.StartDate,
                EndDate = agreement.EndDate,
                StartMileage = agreement.StartMileage,
                EndMileage = agreement.EndMileage,
                DailyRate = agreement.DailyRate,
                TotalAmount = agreement.TotalAmount,
                DepositAmount = agreement.DepositAmount,
                DepositRefunded = agreement.DepositRefunded,
                DepositRefundedDate = agreement.DepositRefundedDate,
                Status = agreement.Status,
                Notes = agreement.Notes
            };
        }

        public async Task<(bool Success, string Message)> CreateRentalAsync(RentalCreateVM vm)
        {
            try
            {
                var dto = new RentalAgreementCreateApiModel
                {
                    CustomerId = vm.CustomerId,
                    RentalVehicleId = vm.VehicleId,
                    StartDate = vm.StartDate,
                    EndDate = vm.EndDate,
                    StartMileage = vm.StartMileage ?? 0,
                    DepositAmount = vm.DepositAmount,
                    Notes = vm.Notes
                };

                var response = await _client.PostAsJsonAsync("api/Rentals/rent", dto);
                var json = await response.Content.ReadAsStringAsync();

                // HTTP basarisiz ise (400, 500 vs.) hata mesajini oku
                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResult = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<object>>(json,
                            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return (false, errorResult?.Message ?? $"API hatasi: {response.StatusCode}");
                    }
                    catch
                    {
                        return (false, $"API hatasi: {response.StatusCode}");
                    }
                }

                var result = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<object>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result != null && result.Success)
                    return (true, result.Message ?? "Kiralama basariyla olusturuldu.");

                return (false, result?.Message ?? "Kiralama basarisiz.");
            }
            catch (HttpRequestException ex)
            {
                return (false, $"API baglanti hatasi: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Beklenmeyen hata: {ex.Message}");
            }
        }

        #endregion
    }
}