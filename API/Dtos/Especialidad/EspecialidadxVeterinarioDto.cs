
using API.Dtos.Veterinario;

namespace API.Dtos.Especialidad
{
    public class EspecialidadxVeterinarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<VeterinarioDto> Veterinarios { get; set; }
    }
}