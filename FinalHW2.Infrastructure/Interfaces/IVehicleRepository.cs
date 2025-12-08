using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Domain.Entities.Vehicles>> GetAllVehiclesAsync();
        Task<Domain.Entities.Vehicles> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Domain.Entities.Vehicles vehicle);
        Task UpdateVehicleAsync(Domain.Entities.Vehicles vehicle);
        Task DeleteVehicleAsync(int id);
    }
}