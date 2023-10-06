
namespace Core.Entities
{
    public class MovimientoMedicamento : BaseEntity
    {
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public DateOnly Fecha { get; set; }
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public Medicamento Medicamento { get; set; }
        public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    }
}