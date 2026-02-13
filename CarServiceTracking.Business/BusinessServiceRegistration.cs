using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Business.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarServiceTracking.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // =========================
            // AutoMapper
            // =========================
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // =========================
            // FluentValidation
            // =========================
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // =========================
            // Business Services
            // =========================
            // Core Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IServiceRequestService, ServiceRequestService>();
            services.AddScoped<ICustomerCarService, CustomerCarService>();

            // Auth Services
            services.AddScoped<ICustomerAuthService, CustomerAuthService>();
            services.AddScoped<IUserAuthService, UserAuthService>();

            // New Module Services
            services.AddScoped<IListItemService, ListItemService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IMechanicService, MechanicService>();
            services.AddScoped<IServiceAssignmentService, ServiceAssignmentService>();
            services.AddScoped<IRentalService, RentalService>();

            return services;
        }
    }
}
