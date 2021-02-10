using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Universalx.Fipple.Identity.DBMap;
using Universalx.Fipple.Identity.DBMap.Entities;

namespace Universalx.Fipple.Identity.Repository.DependencyInjection
{
    public static class ServiceCollections
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
           // services.AddIdentity<Users,Roles>();
        //    services.AddTransient<UserManager<Users>>();
            services.AddDbContext<ApplicationContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
