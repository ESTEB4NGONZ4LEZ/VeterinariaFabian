
namespace Core.Entities
{
    public class MedicamentoProveedor 
    {
        public int MedicamentoId { get; set; }
        public int ProveedorId { get; set; }
        public Medicamento Medicamento { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}