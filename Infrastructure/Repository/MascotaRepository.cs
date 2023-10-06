
using System.IO.Compression;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascota
    {
        public MascotaRepository(MainContext context) : base(context)
        {
        }

        public async Task<dynamic> GetMascotaFelina()
        {
            return await _context.Mascotas.Join
                                          (
                                            _context.Especies,
                                            mascota => mascota.EspecieId,
                                            especie => especie.Id,
                                            (mascota, especie) => new 
                                            {
                                                Mascota = mascota.Nombre,
                                                Especie = especie.Nombre
                                            }
                                          )
                                          .Where(x => x.Especie.ToLower() == "felino")
                                          .ToListAsync();  
        }

        public async Task<dynamic> GetMascotasVacunacion()
        {
            DateTime fechaInicio = new(2023, 01, 01);
            DateTime fechaLimite = new(2023, 03, 31);
 
            return await _context.Mascotas.Join
                                          (
                                            _context.Citas,
                                            mascota => mascota.Id,
                                            cita => cita.MascotaId,
                                            (mascota, cita) => new 
                                            {
                                                Mascota = mascota.Nombre, 
                                                Fecha = cita.Fecha,
                                                Motivo = cita.Motivo
                                            }
                                          )
                                          .Where(x => x.Fecha >= fechaInicio && x.Fecha <= fechaLimite && x.Motivo.ToLower().Contains("vacuna"))
                                          .ToListAsync();
                                          
        }
    }
}