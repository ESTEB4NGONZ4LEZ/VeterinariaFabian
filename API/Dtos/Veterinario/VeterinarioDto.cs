
namespace API.Dtos.Veterinario
{
    public class VeterinarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int EspecialidadId { get; set; }
        // public ICollection<Cita> Citas { get; set; }
    }
}