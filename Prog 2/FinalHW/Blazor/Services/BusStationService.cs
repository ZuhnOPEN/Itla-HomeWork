namespace BusStationUI.Services
{
    using System.Net.Http.Json;

    public class BusStationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:7001/api/busstations";

        public BusStationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BusStationResponseDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BusStationResponseDto>>(ApiUrl) 
                ?? new List<BusStationResponseDto>();
        }

        public async Task<BusStationResponseDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BusStationResponseDto>($"{ApiUrl}/{id}");
        }

        public async Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, dto);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadAsAsync<BusStationResponseDto>())!;
        }

        public async Task UpdateAsync(UpdateBusStationDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{dto.Id}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}