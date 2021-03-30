using System;
using System.Linq.Expressions;
using Universalx.Fipple.Identity.DBMap.Entities;

namespace Universalx.Fipple.Identity.Repository.Abstraction
{
    public interface IRefreshTokenRepository
    {
        RefreshTokens Get(Expression<Func<RefreshTokens, bool>> expression);
        void Update(RefreshTokens refreshTokens);
    }
}
