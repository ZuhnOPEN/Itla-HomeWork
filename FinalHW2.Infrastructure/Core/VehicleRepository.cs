using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Core
{
    public class VehicleRepository : BaseRepository<FinalHW2.Domain.Entities.Vehicles>, FinalHW2.Infrastructure.Interfaces.IVehicleRepository
    {
        public Task<IEnumerable<FinalHW2.Domain.Entities.Vehicles>> GetAllVehiclesAsync() => GetAllAsync();
        public Task<FinalHW2.Domain.Entities.Vehicles> GetVehicleByIdAsync(int id) => Task.FromResult(GetByIdAsync(id).Result!);
        public Task AddVehicleAsync(FinalHW2.Domain.Entities.Vehicles vehicle) => AddAsync(vehicle);
        public Task UpdateVehicleAsync(FinalHW2.Domain.Entities.Vehicles vehicle) => UpdateAsync(vehicle);
        public Task DeleteVehicleAsync(int id) => DeleteAsync(id);
    }
}