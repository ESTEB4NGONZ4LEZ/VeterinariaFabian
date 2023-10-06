
using System.Linq.Expressions;

namespace Core.Interface
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<(int allRegisters, IEnumerable<T> registers)> GetAllAsync(int pageIndex, int pageSize, string search);
    }
}