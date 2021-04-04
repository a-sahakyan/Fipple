using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<RefreshTokens> GetByTokenAsync(string token)
        {
            string sqlQuery = "SELECT * FROM identity.\"RefreshTokens\"" +
                              "WHERE \"Token\" = {0}";

            IQueryable<RefreshTokens> query = applicationContext.RefreshTokens.FromSqlRaw(sqlQuery, token);
            return await query.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(RefreshTokens refreshTokens)
        {
            applicationContext.RefreshTokens.Add(refreshTokens);
            await applicationContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshTokens refreshTokens)
        {
            applicationContext.RefreshTokens.Update(refreshTokens);
            await applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string token)
        {
            var refreshToken = await GetByTokenAsync(token);

            applicationContext.RefreshTokens.Remove(refreshToken);
            await applicationContext.SaveChangesAsync();
        }
    }
}
