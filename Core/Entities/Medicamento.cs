
namespace Core.Entities
{
    public class Medicamento : BaseEntity
    {
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public double Precio { get; set; }
        public int LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
        public ICollection<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
        public ICollection<MedicamentoProveedor> MedicamentoProveedores { get; set; }
        public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    }
}