
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Rol
    {
        public int Id { get; set; }   
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<UserRol> UserRols { get; set; }
    }
}