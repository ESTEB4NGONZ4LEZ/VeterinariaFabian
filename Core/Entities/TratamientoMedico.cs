
namespace Core.Entities
{
    public class TratamientoMedico : BaseEntity
    {   
        public int CitaId { get; set; }
        public int MedicamentoId { get; set; }
        public int Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Observacion { get; set; }
        public Cita Cita { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}