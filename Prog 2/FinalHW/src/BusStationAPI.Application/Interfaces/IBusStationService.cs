using BusStationAPI.Application.Dtos;

namespace BusStationAPI.Application.Interfaces
{
    public interface IBusStationService
    {
        Task<IEnumerable<BusStationResponseDto>> GetAllAsync();
        Task<BusStationResponseDto?> GetByIdAsync(int id);
        Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto);
        Task<BusStationResponseDto> UpdateAsync(UpdateBusStationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
