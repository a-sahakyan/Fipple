using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Universalx.Fipple.Identity.DBMap;
using Universalx.Fipple.Identity.Repository.Abstraction;
using Universalx.Fipple.Identity.Repository.Implementaton;

namespace Universalx.Fipple.Identity.Repository.DependencyInjection
{
    public static class ServiceCollections
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"),
                options => options.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "identity")));
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}
