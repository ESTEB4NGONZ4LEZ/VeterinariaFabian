
namespace Core.Entities
{
    public class Mascota : BaseEntity
    {
        public int PropietarioId { get; set; }
        public int EspecieId { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public Propietario Propietario { get; set; }
        public Especie Especie { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}