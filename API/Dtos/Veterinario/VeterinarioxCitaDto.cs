
using API.Dtos.Cita;

namespace API.Dtos.Veterinario
{
    public class VeterinarioxCitaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int EspecialidadId { get; set; }
        public ICollection<CitaDto> Citas { get; set; }
    }
}