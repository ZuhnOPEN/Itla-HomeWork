using Microsoft.Extensions.DependencyInjection;
using FinalHW2.Infrastructure.Core;
using FinalHW2.Infrastructure.Interfaces;

namespace FinalHW2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Registrar repositorios
            services.AddSingleton<IRouteRepository, RouteRepository>();
            services.AddSingleton<IDriverRepository, DriverRepository>();
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}