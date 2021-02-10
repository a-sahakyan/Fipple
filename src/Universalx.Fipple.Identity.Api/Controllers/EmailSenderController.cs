using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailSenderController : ControllerBase
    {
        private IEmailService emailService;

        public EmailSenderController(IEmailService emailService)
            => this.emailService = emailService;

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {

            string base64Code = "CfDJ8Fs9ckW6poFNku7dw+5aOSXErGH83X2DAdhx3lnquWVkE5OioTh95YHdXaADoXHR0LuTpsl6Ibzi/FWZHbixLr1gj3Eh3wkQlc3L+WfGAuLtOSLsJGmM3zKrn4Dawqg3ZgHPo4PW0SZN0iZum70hEsN04CK94tmyAfZUoedjjlsU3bQEFkzZLrJb9t2xQ2qVOPaW7CTQiK6sVZRLdEt67PIgOT0dvq/gBr69ytPdV0/81VvTYLpluS8trQ1iXWD2kw==";
            byte[] CodeByte = Convert.FromBase64String(base64Code);

            string result = System.Text.Encoding.UTF8.GetString(CodeByte);
            

            await emailService.SendVerificationCode(email);
            return null;
        }
    }
}
