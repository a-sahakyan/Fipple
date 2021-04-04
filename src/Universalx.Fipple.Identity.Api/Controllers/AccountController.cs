using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Api.Helpers;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.Api.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;
        private IEmailService _emailService;
        private IJwtTokenService _jwtTokenService;

        public AccountController(IUserService userService, IEmailService emailService, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _emailService = emailService;
            _jwtTokenService = jwtTokenService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(RequestLoginDto loginDto)
        {
            ResponseUserDto userDto = await _userService.LoginAsync(loginDto);
            ResponseJwtTokenDto jwtToken = await GetJwtTokenAsync(userDto);

            return OkResult(jwtToken);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshTokenAsync(RequestTokenDto tokenDto)
        {
            ResponseUserDto userDto = await _jwtTokenService.UpdateRefreshTokenAsUsedAsync(tokenDto);
            ResponseJwtTokenDto jwtToken = await GetJwtTokenAsync(userDto);

            return OkResult(jwtToken);
        }

        private async Task<ResponseJwtTokenDto> GetJwtTokenAsync(ResponseUserDto userDto)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userDto.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return await _jwtTokenService.GenerateJwtTokenAsync(claims);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync(RequestUserDto userDto)
        {
            ResponseUserDto responseUserDto = await _userService.CreateUserAsync(userDto);
            await SendConfirmAccountEmailAsync(responseUserDto);

            return OkResult();
        }

        private async Task SendConfirmAccountEmailAsync(ResponseUserDto userDto)
        {
            string confirmAccountTemplate = await EmailTemplateBuilder.GetConfirmAccountTemplateAsync(userDto.SecurityStamp);

            string emailSubject = "Verify your new Fipple Account";
            await _emailService.SendEmailAsync(emailSubject, userDto.Email, confirmAccountTemplate);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmAccountAsync(RequestConfirmAccountDto confirmAccountDto)
        {
            await _userService.ConfirmAccountAsync(confirmAccountDto);
            return OkResult();
        }

        [HttpPost]
        public async Task<IActionResult> LogoutAsync([FromBody]RequestTokenDto tokenDto)
        {
            await _jwtTokenService.DeleteRefreshTokenAsync(tokenDto.RefreshToken);
            return OkResult();
        }
    }
}
