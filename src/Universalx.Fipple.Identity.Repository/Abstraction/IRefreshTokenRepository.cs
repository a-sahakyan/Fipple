using System.Threading.Tasks;
using Universalx.Fipple.Identity.DBMap.Entities;

namespace Universalx.Fipple.Identity.Repository.Abstraction
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokens> GetByTokenAsync(string token);
        Task CreateAsync(RefreshTokens refreshTokens);
        Task UpdateAsync(RefreshTokens refreshTokens);
        Task DeleteAsync(string token);
    }
}
