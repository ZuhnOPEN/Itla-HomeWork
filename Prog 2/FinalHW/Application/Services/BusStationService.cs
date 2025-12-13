namespace BusStationAPI.Application.Services
{
    using BusStationAPI.Application.Dtos;
    using BusStationAPI.Application.Interfaces;
    using BusStationAPI.Domain.Entities;
    using BusStationAPI.Domain.Interfaces;

    public class BusStationService : IBusStationService
    {
        private readonly IBusStationRepository _repository;

        public BusStationService(IBusStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<BusStationResponseDto?> GetByIdAsync(int id)
        {
            var busStation = await _repository.GetByIdAsync(id);
            return busStation == null ? null : MapToDto(busStation);
        }

        public async Task<IEnumerable<BusStationResponseDto>> GetAllAsync()
        {
            var busStations = await _repository.GetAllAsync();
            return busStations.Select(MapToDto);
        }

        public async Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto)
        {
            var busStation = new BusStation
            {
                Name = dto.Name,
                City = dto.City,
                Address = dto.Address,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(busStation);
            return MapToDto(created);
        }

        public async Task<BusStationResponseDto> UpdateAsync(UpdateBusStationDto dto)
        {
            var existingStation = await _repository.GetByIdAsync(dto.Id);
            if (existingStation == null)
                throw new KeyNotFoundException($"Estación {dto.Id} no encontrada");

            existingStation.Name = dto.Name;
            existingStation.City = dto.City;
            existingStation.Address = dto.Address;
            existingStation.Phone = dto.Phone;
            existingStation.UpdatedAt = DateTime.UtcNow;

            var updated = await _repository.UpdateAsync(existingStation);
            return MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists)
                throw new KeyNotFoundException($"Estación {id} no encontrada");

            return await _repository.DeleteAsync(id);
        }

        private static BusStationResponseDto MapToDto(BusStation busStation)
        {
            return new BusStationResponseDto
            {
                Id = busStation.Id,
                Name = busStation.Name,
                City = busStation.City,
                Address = busStation.Address,
                Phone = busStation.Phone,
                CreatedAt = busStation.CreatedAt,
                UpdatedAt = busStation.UpdatedAt
            };
        }
    }
}