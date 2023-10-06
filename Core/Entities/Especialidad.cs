
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Especialidad : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Veterinario> Veterinarios { get; set; }
    }
}