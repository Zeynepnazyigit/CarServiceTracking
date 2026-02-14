using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Admin;
using CarServiceTracking.UI.Web.Models.ApiModels.SettingsApiModels;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminSettingsController : AdminBaseController
    {
        private readonly SettingsApiService _settingsApi;

        public AdminSettingsController(SettingsApiService settingsApi)
        {
            _settingsApi = settingsApi;
        }

        public async Task<IActionResult> Index()
        {
            var apiModel = await _settingsApi.GetSettingsAsync();
            var vm = apiModel != null ? MapToVm(apiModel) : new CompanySettingsVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CompanySettingsVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                TempData["Error"] = "Validasyon hatası: " + errors;
                return View(model);
            }

            var apiModel = MapToApiModel(model);
            var (success, message) = await _settingsApi.UpdateSettingsAsync(apiModel);

            if (success)
            {
                TempData["Success"] = message;
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = message;
            return View(model);
        }

        private static CompanySettingsVM MapToVm(CompanySettingsApiModel api)
        {
            return new CompanySettingsVM
            {
                Id = api.Id,
                CompanyName = api.CompanyName,
                Email = api.Email,
                Phone = api.Phone,
                Address = api.Address,
                DefaultLanguage = api.DefaultLanguage,
                Currency = api.Currency,
                DateFormat = api.DateFormat,
                EmailNotifications = api.EmailNotifications,
                SmsNotifications = api.SmsNotifications,
                SessionTimeoutMinutes = api.SessionTimeoutMinutes,
                MinPasswordLength = api.MinPasswordLength,
                TwoFactorAuth = api.TwoFactorAuth
            };
        }

        private static CompanySettingsApiModel MapToApiModel(CompanySettingsVM vm)
        {
            return new CompanySettingsApiModel
            {
                Id = vm.Id,
                CompanyName = vm.CompanyName,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address,
                DefaultLanguage = vm.DefaultLanguage,
                Currency = vm.Currency,
                DateFormat = vm.DateFormat,
                EmailNotifications = vm.EmailNotifications,
                SmsNotifications = vm.SmsNotifications,
                SessionTimeoutMinutes = vm.SessionTimeoutMinutes,
                MinPasswordLength = vm.MinPasswordLength,
                TwoFactorAuth = vm.TwoFactorAuth
            };
        }
    }
}
