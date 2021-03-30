using System.Security.Claims;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IJwtTokenService
    {
        ResponseJwtTokenDto GenerateJwtToken(Claim[] claims);
        Task<ResponseUserDto> UpdateRefreshToken(RequestTokenDto tokenDto);
    }
}
