
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimiento
    {
        public DetalleMovimientoRepository(MainContext context) : base(context)
        {
        }
    }
}