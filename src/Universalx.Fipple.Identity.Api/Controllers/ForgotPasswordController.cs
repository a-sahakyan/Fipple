using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Api.Helpers;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    public class ForgotPasswordController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public ForgotPasswordController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            ResponseUserDto userDto = await _userService.GetUserByEmail(email);
            await SendConfirmResetPasswordEmailAsync(userDto);

            return OkResult();
        }

        private async Task SendConfirmResetPasswordEmailAsync(ResponseUserDto userDto)
        {
            string confirmAccountTemplate = await EmailTemplateBuilder.GetConfirmResetPasswordTemplateAsync(userDto.FirstName, userDto.SecurityStamp);

            string emailSubject = "Reset Fipple Password";
            await _emailService.SendEmailAsync(emailSubject, userDto.Email, confirmAccountTemplate);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmResetPasswordAsync(RequestConfirmAccountDto confirmAccountDto)
        {
            await _userService.ConfirmVerificationCodeAsync(confirmAccountDto);
            return OkResult();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync(RequestResetPasswordDto resetPasswordDto)
        {
            await _userService.ResetPasswordAsync(resetPasswordDto);
            return OkResult();
        }
    }
}
