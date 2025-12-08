using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Domain.Core.Drivers>> GetAllDriversAsync();
        Task<Domain.Core.Drivers> GetDriverByIdAsync(int id);
        Task AddDriverAsync(Domain.Core.Drivers driver);
        Task UpdateDriverAsync(Domain.Core.Drivers driver);
        Task DeleteDriverAsync(int id);
    }
}