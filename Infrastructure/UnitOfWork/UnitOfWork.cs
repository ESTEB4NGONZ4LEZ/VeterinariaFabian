
using Infrastructure.Repository;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainContext _context;
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        private UserRepository _users;
        private RolRepository _rols;
        private RefreshTokenRepository _refreshToken;

        public IUser Users 
        {
            get
            {
                _users ??= new UserRepository(_context);
                return _users;
            }
        }

        public IRol Rols
        {
            get
            {
                _rols ??= new RolRepository(_context);
                return _rols;
            }
        }

        public IRefreshToken RefreshToken
        {
            get
            {
                _refreshToken ??= new RefreshTokenRepository(_context);
                return _refreshToken;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}