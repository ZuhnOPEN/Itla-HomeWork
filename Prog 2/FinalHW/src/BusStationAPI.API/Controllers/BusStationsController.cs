#nullable enable
namespace BusStationAPI.API.Controllers
{
    using BusStationAPI.Application.Dtos;
    using BusStationAPI.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BusStationsController : ControllerBase
    {
        private readonly IBusStationService _service;

        public BusStationsController(IBusStationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusStationResponseDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusStationResponseDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound(new { message = $"Estación {id} no encontrada" });

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<BusStationResponseDto>> Create(CreateBusStationDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BusStationResponseDto>> Update(int id, UpdateBusStationDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "El ID no coincide." });

            try
            {
                var updated = await _service.UpdateAsync(dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Estación {id} no encontrada" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Estación {id} no encontrada" });

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Estación {id} no encontrada" });
            }
        }
    }
}
