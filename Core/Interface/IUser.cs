
using Core.Entities;

namespace Core.Interface
{
    public interface IUser : IGeneric<User>
    {
        Task<User> GetUserByUsername(string username);
    }
}