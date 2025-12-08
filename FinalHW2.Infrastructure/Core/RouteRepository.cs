using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Core
{
    public class RouteRepository : BaseRepository<FinalHW2.Domain.Entities.Routes>, FinalHW2.Infrastructure.Interfaces.IRouteRepository
    {

        public Task<IEnumerable<FinalHW2.Domain.Entities.Routes>> GetAllRoutesAsync() => GetAllAsync();
        public Task<FinalHW2.Domain.Entities.Routes> GetRouteByIdAsync(int id) => Task.FromResult(GetByIdAsync(id).Result!);
        public Task AddRouteAsync(FinalHW2.Domain.Entities.Routes route) => AddAsync(route);
        public Task UpdateRouteAsync(FinalHW2.Domain.Entities.Routes route) => UpdateAsync(route);
        public Task DeleteRouteAsync(int id) => DeleteAsync(id);
    }
}
