
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class RazaRepository : GenericRepository<Raza>, IRaza
    {
        public RazaRepository(MainContext context) : base(context)
        {
        }
    }
}