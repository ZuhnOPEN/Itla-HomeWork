using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Core
{
    public class ScheduleRepository : BaseRepository<FinalHW2.Domain.Entities.Schedule>, FinalHW2.Infrastructure.Interfaces.IScheduleRepository
    {
        public Task<IEnumerable<FinalHW2.Domain.Entities.Schedule>> GetAllSchedulesAsync() => GetAllAsync();
        public Task<FinalHW2.Domain.Entities.Schedule> GetScheduleByIdAsync(int id) => Task.FromResult(GetByIdAsync(id).Result!);
        public Task AddScheduleAsync(FinalHW2.Domain.Entities.Schedule schedule) => AddAsync(schedule);
        public Task UpdateScheduleAsync(FinalHW2.Domain.Entities.Schedule schedule) => UpdateAsync(schedule);
        public Task DeleteScheduleAsync(int id) => DeleteAsync(id);
    }
}