
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
            return await _context.Propietarios.Select
                                              (
                                                propietario => new
                                                {
                                                    Id = propietario.Id,
                                                    Propietario = propietario.Nombre,
                                                    Mascotas = _context.Mascotas.Select
                                                                                (
                                                                                    mascota => new
                                                                                    {
                                                                                        Id = mascota.Id,
                                                                                        Mascota = mascota.Nombre,
                                                                                        Especie = mascota.EspecieId,
                                                                                        Propietario = mascota.PropietarioId,
                                                                                        Nacimiento = mascota.FechaNacimiento
                                                                                    } 
                                                                                )
                                                                                .Where(x => x.Propietario == propietario.Id)
                                                                                .ToList()

                                                }
                                              ).ToListAsync();
        }
    }
}