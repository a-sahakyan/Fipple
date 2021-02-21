using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Api.Helpers;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController
    {
        private IUserService _userService;
        private IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService)
            => (_userService, _emailService) = (userService, emailService);

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(RequestUserDto userDto)
        {          
            ResponseUserDto responseUserDto = await _userService.CreateUserAsync(userDto);
            await SendVerifyAccountEmailAsync(responseUserDto);

            return OkResult();
        }

        private async Task SendVerifyAccountEmailAsync(ResponseUserDto userDto)
        {
            string verifyAccountTemplate = await EmailTemplateBuilder.GetVerifyAccountTemplateAsync(userDto.SecurityStamp);
            string emailSubject = "Verify your new Fipple Account";
            await _emailService.SendEmailAsync(emailSubject, userDto.Email, verifyAccountTemplate);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAccountAsync(RequestConfirmAccountDto confirmAccountDto)
        {
            await _userService.ConfirmAccountAsync(confirmAccountDto);
            return Ok();
        }
    }
}
