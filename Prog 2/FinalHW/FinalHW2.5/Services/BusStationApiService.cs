#nullable enable
namespace FinalHW2._5.Services
{
    using System.Net.Http.Json;
    using Microsoft.Extensions.Logging;

    public class BusStationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BusStationApiService> _logger;
        private const string ApiBase = "api/busstations";

        public BusStationApiService(HttpClient httpClient, ILogger<BusStationApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<BusStationResponseDto>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation($"Obteniendo todas las estaciones desde {_httpClient.BaseAddress}{ApiBase}");
                
                var response = await _httpClient.GetAsync(ApiBase);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error HTTP {response.StatusCode}: {errorContent}");
                    throw new HttpRequestException($"Error HTTP {response.StatusCode}: {response.ReasonPhrase}. Contenido: {errorContent}");
                }
                
                var result = await response.Content.ReadFromJsonAsync<List<BusStationResponseDto>>();
                _logger.LogInformation($"Se obtuvieron {result?.Count ?? 0} estaciones exitosamente");
                
                return result ?? new List<BusStationResponseDto>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error HTTP: {ex.Message}");
                throw new Exception($"Error al conectar con la API en {_httpClient.BaseAddress}{ApiBase}: {ex.Message}. Verifica que la API esté ejecutándose.");
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                _logger.LogError($"Timeout al conectar con la API: {ex.Message}");
                throw new Exception($"Timeout al conectar con la API en {_httpClient.BaseAddress}{ApiBase}. Verifica que la API esté ejecutándose y responda correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public async Task<BusStationResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<BusStationResponseDto>($"{ApiBase}/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estación {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<BusStationResponseDto> CreateAsync(CreateBusStationDto dto)
        {
            try
            {
                var resp = await _httpClient.PostAsJsonAsync(ApiBase, dto);
                resp.EnsureSuccessStatusCode();
                return (await resp.Content.ReadFromJsonAsync<BusStationResponseDto>())!;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear estación: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(UpdateBusStationDto dto)
        {
            try
            {
                var resp = await _httpClient.PutAsJsonAsync($"{ApiBase}/{dto.Id}", dto);
                resp.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar estación {dto.Id}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var resp = await _httpClient.DeleteAsync($"{ApiBase}/{id}");
                resp.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar estación {id}: {ex.Message}");
                throw;
            }
        }
    }

    public class CreateBusStationDto
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class UpdateBusStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class BusStationResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
