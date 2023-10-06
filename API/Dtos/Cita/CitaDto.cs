
namespace API.Dtos.Cita
{
    public class CitaDto
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public int VeterinarioId { get; set; }
        // public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }
    }
}