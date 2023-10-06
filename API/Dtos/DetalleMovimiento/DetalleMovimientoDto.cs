
namespace API.Dtos.DetalleMovimiento
{
    public class DetalleMovimientoDto
    {
        public int Id { get; set; }
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public int MovimientoMedicamentoId { get; set; }
        public double Precio { get; set; }
    }
}