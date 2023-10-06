
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class EspecieRepository : GenericRepository<Especie>, IEspecie
    {
        public EspecieRepository(MainContext context) : base(context)
        {
        }
    }
}