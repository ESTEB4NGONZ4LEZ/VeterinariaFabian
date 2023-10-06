
namespace API.Dtos.MovimientoMedicamento
{
    public class MovimientoMedicamentoDto
    {
        public int Id { get; set; }
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public DateOnly Fecha { get; set; }
        public int TipoMovimientoId { get; set; }
    }
}