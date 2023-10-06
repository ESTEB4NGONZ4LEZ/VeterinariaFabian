
namespace Core.Entities
{
    public class Veterinario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}