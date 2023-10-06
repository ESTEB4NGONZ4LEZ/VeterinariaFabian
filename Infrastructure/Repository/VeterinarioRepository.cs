
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
    {
        public VeterinarioRepository(MainContext context) : base(context)
        {
        }

        public async Task<dynamic> GetCirujanoVascular()
        {
            return await _context.Veterinarios.Join
                                              (
                                                _context.Especialidades,
                                                veterinario => veterinario.EspecialidadId,
                                                especialidad => especialidad.Id,
                                                (veterinario, especialidad) => new 
                                                {
                                                    Veterinario = veterinario.Nombre,
                                                    Especialidad = especialidad.Nombre
                                                }
                                               )
                                               .Where(x => x.Especialidad.ToLower() == "cirujano vascular")
                                               .ToListAsync();
                                            
        }
    }
}