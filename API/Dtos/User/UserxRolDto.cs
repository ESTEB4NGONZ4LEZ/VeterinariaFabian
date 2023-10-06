using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Rol;

namespace API.Dtos.User
{
    public class UserxRolDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RolDto> Rols { get; set; }
    }
}