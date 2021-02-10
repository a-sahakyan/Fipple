using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.BusinessLogic.Services;
using Universalx.Fipple.Identity.DBMap.Entities;
using Universalx.Fipple.Identity.Repository.DependencyInjection;

namespace Universalx.Fipple.Identity.BusinessLogic.DependencyInjection
{
    public static class ServiceCollections
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.ConfigureRepositories(configuration);
        }
    }
}
