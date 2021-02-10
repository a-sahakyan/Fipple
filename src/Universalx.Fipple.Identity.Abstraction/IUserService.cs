using System.Threading.Tasks;
using Universalx.Fipple.Identity.DTO.Request;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IUserService
    {
        Task CreateAsync(RequestUserDto userDto);
    }
}
