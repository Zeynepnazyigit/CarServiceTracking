using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace CarServiceTracking.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarService, CarService>(); // ✅ EKLE

            return services;
        }
    }
}
