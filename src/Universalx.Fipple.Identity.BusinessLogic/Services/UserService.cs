using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Constants;
using Universalx.Fipple.Identity.DBMap.Entities;
using Universalx.Fipple.Identity.DTO.Request;

namespace Universalx.Fipple.Identity.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private UserManager<Users> _userManager;

        public UserService(UserManager<Users> userManager)
              => _userManager = userManager;

        public async Task CreateAsync(RequestUserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user is not null) throw new InvalidOperationException(String.Format(Resources.Error.UserNotFound, user.Email));

            var newUser = new Users
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Email,
                PasswordHash = userDto.Password
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser);

            // TODO: improve Error
            if (!identityResult.Succeeded) throw new InvalidOperationException(String.Format(identityResult.Errors.First().Description, user.Email));
        }
    }
}
