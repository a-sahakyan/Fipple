using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Universalx.Fipple.Identity.DBMap;

namespace Universalx.Fipple.Identity.Repository.DependencyInjection
{
    public static class ServiceCollections
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
