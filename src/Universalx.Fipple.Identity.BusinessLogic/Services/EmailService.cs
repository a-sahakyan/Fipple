using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.DTO.Configuration;

namespace Universalx.Fipple.Identity.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptionsSnapshot<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string subject, string reciever, string message)
        {
            if (emailSettings.IsTest)
            {
                reciever = emailSettings.Receiver;
            }

            using var client = new SmtpClient(emailSettings.MailHost, emailSettings.MailPort);

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(emailSettings.Sender, emailSettings.SenderPassword);

            MailMessage mailMessage = new MailMessage(emailSettings.Sender, reciever);

            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            await client.SendMailAsync(mailMessage);
        }
    }
}
