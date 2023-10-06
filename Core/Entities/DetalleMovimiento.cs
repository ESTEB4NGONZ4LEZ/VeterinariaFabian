
namespace Core.Entities
{
    public class DetalleMovimiento : BaseEntity
    { 
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public int MovimientoMedicamentoId { get; set; }
        public double Precio { get; set; }
        public Medicamento Medicamento { get; set; }
        public MovimientoMedicamento MovimientoMedicamento { get; set; }
    }
}