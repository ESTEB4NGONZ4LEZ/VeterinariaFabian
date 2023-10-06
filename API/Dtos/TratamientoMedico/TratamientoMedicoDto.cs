
namespace API.Dtos.TratamientoMedico
{
    public class TratamientoMedicoDto 
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public int MedicamentoId { get; set; }
        public int Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Observacion { get; set; }
    }
}