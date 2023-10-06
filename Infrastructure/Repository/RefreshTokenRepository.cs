
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.Repository
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
    {
        public RefreshTokenRepository(MainContext context) : base(context)
        {
        }
    }
}