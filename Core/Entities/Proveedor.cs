
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Proveedor : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [MaxLength(20)]
        [Required]
        public string Telefono { get; set; }
        public ICollection<MedicamentoProveedor> MedicamentoProveedores { get; set; }        
    }
}