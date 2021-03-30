using System;
using System.Linq;
using System.Linq.Expressions;
using Universalx.Fipple.Identity.DBMap;
using Universalx.Fipple.Identity.DBMap.Entities;
using Universalx.Fipple.Identity.Repository.Abstraction;

namespace Universalx.Fipple.Identity.Repository.Implementaton
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationContext applicationContext;

        public RefreshTokenRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public RefreshTokens Get(Expression<Func<RefreshTokens, bool>> expression)
        {
            return applicationContext.RefreshTokens.FirstOrDefault(expression);
        }
        
        public void Update(RefreshTokens refreshTokens)
        {
            applicationContext.RefreshTokens.Update(refreshTokens);
            applicationContext.SaveChanges();
        }
    }
}
