using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarServiceTracking.Business.IOC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceRequestService, ServiceRequestService>();

            return services;
        }
    }
}
