
namespace Core.Interface
{
    public interface IUnitOfWork
    {
        IUser Users { get; }
        IRol Rols { get; }
        IRefreshToken RefreshToken { get; }
        Task<int> SaveAsync();
    }
}