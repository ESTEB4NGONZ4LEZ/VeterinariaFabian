
namespace Core.Entities
{
    public class Cita : BaseEntity
    {
        public int MascotaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public int VeterinarioId { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
        public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }
    }
}