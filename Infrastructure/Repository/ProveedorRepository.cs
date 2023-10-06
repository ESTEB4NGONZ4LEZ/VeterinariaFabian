
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        public ProveedorRepository(MainContext context) : base(context)
        {
        }
    }
}