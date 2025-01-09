using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moongazing.TenancyConfigManager.Contexts;
using Moongazing.TenancyConfigManager.Services;

namespace Moongazing.TenancyConfigManager
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMultiTenantConfiguration(this IServiceCollection services,
                                                                     IConfiguration configuration,
                                                                     Action<DbContextOptionsBuilder> dbOptionsAction)
        {
            services.AddDbContext<ApplicationDbContext>(dbOptionsAction);

            services.AddScoped<ITenantConfigurationService, TenantConfigurationService>();

            return services;
        }
    }
}
