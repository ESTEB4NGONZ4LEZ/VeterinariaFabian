
namespace API.Dtos.Mascota
{
    public class MascotaDto
    {
        public int Id { get; set; }
        public int PropietarioId { get; set; }
        public int EspecieId { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaNacimiento { get; set; }
    }
}