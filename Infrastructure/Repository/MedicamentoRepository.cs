
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
    {
        public MedicamentoRepository(MainContext context) : base(context)
        {
        }

        public async Task<dynamic> GetMedicamentoGenfar()
        {
            return await _context.Medicamentos.Join
                                              (
                                                _context.Laboratorios,
                                                medicamento => medicamento.LaboratorioId,
                                                laboratorio => laboratorio.Id,
                                                (medicamento, laboratorio) => new
                                                {
                                                    Medicamento = medicamento.Nombre,
                                                    Precio = medicamento.Precio,
                                                    Laboratorio = laboratorio.Nombre,
                                                    Direccion = laboratorio.Direccion
                                                }
                                              ).Where(x => x.Laboratorio.ToLower() == "genfar")
                                              .ToListAsync();
        }

        public async Task<dynamic> GetMedicamentos50000()
        {
            return await _context.Medicamentos.Select
                                              (
                                                medicamento => new 
                                                {
                                                    Id = medicamento.Id,
                                                    Nombre = medicamento.Nombre,
                                                    Cantidad = medicamento.CantidadDisponible,
                                                    LaboratorioId = medicamento.LaboratorioId,
                                                    Precio = medicamento.Precio
                                                }
                                              )
                                              .Where(x => x.Precio > 50000)
                                              .ToListAsync();
        }
    }
}