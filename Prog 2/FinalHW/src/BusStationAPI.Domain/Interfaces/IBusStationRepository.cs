#nullable enable
namespace BusStationAPI.Domain.Interfaces
{
    using BusStationAPI.Domain.Entities;

    public interface IBusStationRepository
    {
        Task<BusStation?> GetByIdAsync(int id);
        Task<IEnumerable<BusStation>> GetAllAsync();
        Task<BusStation> AddAsync(BusStation busStation);
        Task<BusStation> UpdateAsync(BusStation busStation);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}