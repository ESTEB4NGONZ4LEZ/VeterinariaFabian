
using Core.Entities;

namespace Core.Interface
{
    public interface IMedicamento : IGeneric<Medicamento>
    {
        Task<dynamic> GetMedicamentoGenfar();
        Task<dynamic> GetMedicamentos50000();
    }
}