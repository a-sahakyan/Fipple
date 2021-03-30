using System.Threading.Tasks;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IUserService
    {
        Task<ResponseUserDto> LoginAsync(RequestLoginDto userDto);
        Task<ResponseUserDto> CreateUserAsync(RequestUserDto userDto);
        Task ConfirmAccountAsync(RequestConfirmAccountDto confirmAccountDto);
        Task<ResponseUserDto> GetUserByEmail(string email);
        Task ConfirmVerificationCodeAsync(RequestConfirmAccountDto confirmAccountDto);
        Task ResetPasswordAsync(RequestResetPasswordDto resetPasswordDto);
    }
}
