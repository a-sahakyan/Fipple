using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.DBMap.Entities;

namespace Universalx.Fipple.Identity.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private UserManager<Users> userManager;

        public EmailService(UserManager<Users> userManager)
              => this.userManager = userManager;

        public async Task SendVerificationCode(string email)
        {
            try
            {
                var user = new Users
                {
                    UserName = email,
                    Email = email,
                    FirstName = "aaa",
                    LastName = "bbb",
                };

                var result = await userManager.CreateAsync(user, "qwe123QWEaffafa;");
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
