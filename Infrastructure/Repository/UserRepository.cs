
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        public UserRepository(MainContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await  _context.Users.Where(x => x.Username.ToLower() == username.ToLower())
                                       .Include(x => x.Rols)
                                       .FirstOrDefaultAsync();
        }
    }
}