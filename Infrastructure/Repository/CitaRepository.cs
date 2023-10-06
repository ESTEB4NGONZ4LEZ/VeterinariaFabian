
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class CitaRepository : GenericRepository<Cita>, ICita
    {
        public CitaRepository(MainContext context) : base(context)
        {
        }
    }
}