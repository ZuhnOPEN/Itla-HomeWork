#nullable enable
namespace BusStationAPI.Infrastructure.Repositories
{
    using BusStationAPI.Domain.Entities;
    using BusStationAPI.Domain.Interfaces;
    using BusStationAPI.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class BusStationRepository : IBusStationRepository
    {
        private readonly AppDbContext _context;

        public BusStationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BusStation?> GetByIdAsync(int id)
        {
            return await _context.BusStations.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BusStation>> GetAllAsync()
        {
            return await _context.BusStations.OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<BusStation> AddAsync(BusStation busStation)
        {
            await _context.BusStations.AddAsync(busStation);
            await _context.SaveChangesAsync();
            return busStation;
        }

        public async Task<BusStation> UpdateAsync(BusStation busStation)
        {
            // Obtener la entidad original para preservar CreatedAt
            var existingEntity = await _context.BusStations.FindAsync(busStation.Id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"La estación con ID {busStation.Id} no fue encontrada.");

            // Preservar CreatedAt original y actualizar los demás campos
            existingEntity.Name = busStation.Name;
            existingEntity.City = busStation.City;
            existingEntity.Address = busStation.Address;
            existingEntity.Phone = busStation.Phone;
            existingEntity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.BusStations.FindAsync(id);
            if (entity == null)
                return false;

            _context.BusStations.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.BusStations.AnyAsync(b => b.Id == id);
        }
    }
}
