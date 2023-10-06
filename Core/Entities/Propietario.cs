
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Propietario : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [MaxLength(20)]
        [Required]
        public string Telefono { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}