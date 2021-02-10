using System.Threading.Tasks;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IEmailService
    {
        Task SendVerificationCode(string code);
    }
}
