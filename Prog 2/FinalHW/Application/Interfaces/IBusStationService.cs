namespace BusStationAPI.Application.Interfaces
{
    public interface IBusStationService
    {
        Task<BusStationResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<BusStationResponseDto>> GetAllAsync();
        Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto);
        Task<BusStationResponseDto> UpdateAsync(UpdateBusStationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}