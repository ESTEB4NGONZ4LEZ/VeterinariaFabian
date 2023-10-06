
using Core.Entities;

namespace Core.Interface
{
    public interface IVeterinario : IGeneric<Veterinario>
    {
        Task<dynamic> GetCirujanoVascular();
    }
}