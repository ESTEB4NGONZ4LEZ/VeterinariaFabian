
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        public RolRepository(MainContext context) : base(context)
        {
        }
    }
}