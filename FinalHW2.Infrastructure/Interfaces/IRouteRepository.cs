using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Interfaces
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Domain.Entities.Routes>> GetAllRoutesAsync();
        Task<Domain.Entities.Routes> GetRouteByIdAsync(int id);
        Task AddRouteAsync(Domain.Entities.Routes route);
        Task UpdateRouteAsync(Domain.Entities.Routes route);
        Task DeleteRouteAsync(int id);
    }
}
