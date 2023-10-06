
using Core.Entities;

namespace Core.Interface
{
    public interface IPropietario : IGeneric<Propietario>
    {
        Task<dynamic> GetPropietarioxMasxotas();
    }
}