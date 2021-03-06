using System;
using System.IO;
using System.Threading.Tasks;

namespace Universalx.Fipple.Identity.Api.Helpers
{
    public static class EmailTemplateBuilder
    {
        public static async Task<string> GetConfirmAccountTemplateAsync(params string[] messageData)
        {
            if (messageData is null)
            {
                throw new ArgumentNullException(nameof(messageData), "Cannot be null");
            }

            string template = await ReadTemplate(EmailTempalteType.ConfirmAccountTemplate);
            return string.Format(template, messageData);
        }

        public static async Task<string> GetConfirmResetPasswordTemplateAsync(params string[] messageData)
        {
            if (messageData is null)
            {
                throw new ArgumentNullException(nameof(messageData), "Cannot be null");
            }
            
            string template = await ReadTemplate(EmailTempalteType.ConfirmResetPasswordTemplate);
            return string.Format(template, messageData);
        }

        private static async Task<string> ReadTemplate(EmailTempalteType emailTempalteType)
        {
            string templateName = string.Concat(emailTempalteType, ".html");
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates", templateName);
            return await File.ReadAllTextAsync(templatePath);
        }
    }

    public enum EmailTempalteType
    {
        ConfirmAccountTemplate = 1,
        ConfirmResetPasswordTemplate = 2
    }
}
