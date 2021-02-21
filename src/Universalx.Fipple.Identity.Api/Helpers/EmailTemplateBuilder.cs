using System;
using System.IO;
using System.Threading.Tasks;

namespace Universalx.Fipple.Identity.Api.Helpers
{
    public static class EmailTemplateBuilder
    {
        public async static Task<string> GetVerifyAccountTemplateAsync(params string[] messageData)
        {
            if(messageData is null)
            {
                throw new ArgumentNullException(nameof(messageData), "Cannot be null");
            }

            string template = await ReadTemplate(EmailTempalteType.VerifyAccountTemplate);
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
        VerifyAccountTemplate = 1
    }
}
