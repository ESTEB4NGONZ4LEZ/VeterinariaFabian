
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Especie : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public ICollection<Raza> Razas { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}