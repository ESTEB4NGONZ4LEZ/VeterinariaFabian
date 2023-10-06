
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
    {
        public MovimientoMedicamentoRepository(MainContext context) : base(context)
        {
        }
    }
}