
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EspecialidadRepository : GenericRepository<Especialidad>, IEspecialidad
    {
        public EspecialidadRepository(MainContext context) : base(context)
        {
        }

        public async Task<Especialidad> GetByIdAsync(int id)
        {
            return await  _context.Especialidades.Where(x => x.Id == id)
                                                 .Include(x => x.Veterinarios)
                                                 .FirstOrDefaultAsync();
        }

        public override async Task<(int allRegisters, IEnumerable<Especialidad> registers)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Especialidades as IQueryable<Especialidad>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Nombre.ToLower().Contains(search));
            }
            var allRegisters = await query.CountAsync();
            var registers = await query.Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();
            return (allRegisters, registers);
        }
    }
}