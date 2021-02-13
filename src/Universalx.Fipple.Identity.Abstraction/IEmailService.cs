using System.Threading.Tasks;

namespace Universalx.Fipple.Identity.Abstraction
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string reciever, string message);
    }
}
