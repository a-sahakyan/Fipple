using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Constants;
using Universalx.Fipple.Identity.DBMap.Entities;
using Universalx.Fipple.Identity.DTO.Exception;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;

namespace Universalx.Fipple.Identity.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private UserManager<Users> _userManager;

        public UserService(UserManager<Users> userManager)
              => _userManager = userManager;

        public async Task<ResponseUserDto> CreateUserAsync(RequestUserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user is not null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, string.Format(ResponseError.UserAlreadyExists, user.Email));
            }

            user = new Users
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Email,
                PasswordHash = userDto.Password
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException(identityResult.Errors.First().Description);
            }

            var responseUserDto = new ResponseUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                SecurityStamp = user.SecurityStamp
            };

            return responseUserDto;
        }

        public async Task ConfirmAccountAsync(RequestConfirmAccountDto confirmAccountDto)
        {
            var user = await _userManager.FindByEmailAsync(confirmAccountDto.Email);

            if (user is null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, string.Format(ResponseError.UserNotFound, confirmAccountDto.Email));
            }

            if (confirmAccountDto.VerificationCode != user.SecurityStamp)
            {
                throw new HttpException(HttpStatusCode.BadRequest, ResponseError.WrongCode);
            }

            user.EmailConfirmed = true;
            IdentityResult identityResult = await _userManager.UpdateAsync(user);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException(identityResult.Errors.First().Description);
            }
        }
    }
}

