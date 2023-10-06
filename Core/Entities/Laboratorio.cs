
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Laboratorio : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [MaxLength(20)]
        [Required]
        public string Telefono { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }   
    }
}