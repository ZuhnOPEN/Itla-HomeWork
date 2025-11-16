using Microsoft.Extensions.DependencyInjection;
using PublicManagment.Domain.Repositories;
using PublicManagment.Infrastructure.Repositories;
using PublicManagment.Infrastructure.Core;

namespace PublicManagment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPublicManagmentInfrastructure(this IServiceCollection services)
        {
            // Core infra
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
            services.AddSingleton<IGuidProvider, GuidProvider>();
            services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();

            // Implementación in-memory por defecto. Sustituir por EF/DB real si se desea.
            services.AddSingleton<ITripRepository, InMemoryTripRepository>();
            services.AddSingleton<IDriverRepository, InMemoryDriverRepository>();
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddSingleton<IStopRepository, InMemoryStopRepository>();
            services.AddSingleton<ILineRepository, InMemoryLineRepository>();

            return services;
        }
    }
}