using System.Security.Claims;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IJwtTokenService
    {
        Task<ResponseJwtTokenDto> GenerateJwtTokenAsync(Claim[] claims);
        Task<ResponseUserDto> UpdateRefreshTokenAsUsedAsync(RequestTokenDto tokenDto);
        Task DeleteRefreshTokenAsync(string token);
    }
}
