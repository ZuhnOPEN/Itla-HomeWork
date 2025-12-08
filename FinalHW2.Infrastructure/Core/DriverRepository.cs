using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Core
{
    public class DriverRepository : BaseRepository<FinalHW2.Domain.Core.Drivers>, FinalHW2.Infrastructure.Interfaces.IDriverRepository
    {
        public Task<IEnumerable<FinalHW2.Domain.Core.Drivers>> GetAllDriversAsync() => GetAllAsync();
        public Task<FinalHW2.Domain.Core.Drivers> GetDriverByIdAsync(int id) => Task.FromResult(GetByIdAsync(id).Result!);
        public Task AddDriverAsync(FinalHW2.Domain.Core.Drivers driver) => AddAsync(driver);
        public Task UpdateDriverAsync(FinalHW2.Domain.Core.Drivers driver) => UpdateAsync(driver);
        public Task DeleteDriverAsync(int id) => DeleteAsync(id);
    }
}