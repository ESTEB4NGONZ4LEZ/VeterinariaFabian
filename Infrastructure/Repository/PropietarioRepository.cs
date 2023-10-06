
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
    {
        public PropietarioRepository(MainContext context) : base(context)
        {
        }

        public async Task<dynamic> GetPropietarioxMasxotas()
        {
            return await _context.Propietarios.Join 
                                              (
                                                _context.Mascotas,
                                                propietario => propietario.Id,
                                                mascota => mascota.PropietarioId,
                                                (propietario, mascota) => new 
                                                {
                                                    Propietario = propietario.Nombre,
                                                    Mascotas = mascota.Nombre
                                                }
                                              )
                                              .ToListAsync();
        }
    }
}