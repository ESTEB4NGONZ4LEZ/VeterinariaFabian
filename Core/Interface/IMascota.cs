
using Core.Entities;

namespace Core.Interface
{
    public interface IMascota : IGeneric<Mascota>
    {
        Task<dynamic> GetMascotaFelina();
        Task<dynamic> GetMascotasVacunacion();
    }
}