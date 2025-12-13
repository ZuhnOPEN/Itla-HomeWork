using System.ComponentModel.DataAnnotations;

namespace BusStationAPI.Application.Dtos
{
    public class CreateBusStationDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 255 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es requerida")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "La ciudad debe tener entre 2 y 100 caracteres")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 500 caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 caracteres")]
        public string Phone { get; set; } = string.Empty;
    }
}
