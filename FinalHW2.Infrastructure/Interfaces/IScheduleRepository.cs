using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Domain.Entities.Schedule>> GetAllSchedulesAsync();
        Task<Domain.Entities.Schedule> GetScheduleByIdAsync(int id);
        Task AddScheduleAsync(Domain.Entities.Schedule schedule);
        Task UpdateScheduleAsync(Domain.Entities.Schedule schedule);
        Task DeleteScheduleAsync(int id);
    }
}