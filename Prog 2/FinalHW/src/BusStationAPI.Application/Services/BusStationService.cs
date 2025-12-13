using BusStationAPI.Application.Dtos;
using BusStationAPI.Application.Interfaces;
using BusStationAPI.Domain.Entities;
using BusStationAPI.Domain.Interfaces;

namespace BusStationAPI.Application.Services
{
    public class BusStationService : IBusStationService
    {
        private readonly IBusStationRepository _repository;

        public BusStationService(IBusStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusStationResponseDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToResponseDto);
        }

        public async Task<BusStationResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToResponseDto(entity);
        }

        public async Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto)
        {
            var entity = new BusStation
            {
                Name = dto.Name,
                City = dto.City,
                Address = dto.Address,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow  // Asignar fecha de creación explícitamente
            };

            var created = await _repository.AddAsync(entity);
            return MapToResponseDto(created);
        }

        public async Task<BusStationResponseDto> UpdateAsync(UpdateBusStationDto dto)
        {
            var exists = await _repository.ExistsAsync(dto.Id);
            if (!exists)
                throw new KeyNotFoundException($"La estación con ID {dto.Id} no fue encontrada.");

            var entity = new BusStation
            {
                Id = dto.Id,
                Name = dto.Name,
                City = dto.City,
                Address = dto.Address,
                Phone = dto.Phone,
                UpdatedAt = DateTime.UtcNow  // Asignar fecha de actualización explícitamente
            };

            var updated = await _repository.UpdateAsync(entity);
            return MapToResponseDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private static BusStationResponseDto MapToResponseDto(BusStation entity)
        {
            return new BusStationResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
                Address = entity.Address,
                Phone = entity.Phone,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
