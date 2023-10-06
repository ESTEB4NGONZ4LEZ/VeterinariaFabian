
namespace Core.Entities
{
    public class Raza : BaseEntity
    {
        public string Nombre { get; set; }
        public int EspecieId { get; set; }
        public Especie Especie { get; set; }
    }
}