
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimiento
    {
        public TipoMovimientoRepository(MainContext context) : base(context)
        {
        }
    }
}