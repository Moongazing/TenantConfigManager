using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moongazing.TenancyConfigManager.Contexts;

namespace Moongazing.TenancyConfigManager.Services;

public class TenantConfigurationService : ITenantConfigurationService
{
    private readonly ApplicationDbContext dbContext;
    private readonly IConfiguration globalConfiguration;

    public TenantConfigurationService(ApplicationDbContext dbContext, IConfiguration globalConfiguration)
    {
        this.dbContext = dbContext;
        this.globalConfiguration = globalConfiguration;
    }

    public async Task<IConfiguration> GetConfigurationAsync(string tenantId)
    {
        var configurationBuilder = new ConfigurationBuilder().AddConfiguration(globalConfiguration);

        var tenantConfigurations = await dbContext.TenantConfigurations
            .Where(tc => tc.TenantId == tenantId)
            .ToListAsync();

        if (tenantConfigurations.Count != 0)
        {
            configurationBuilder.AddInMemoryCollection(
                tenantConfigurations.ToDictionary(tc => tc.Key, tc => tc.Value)!);
        }

        return configurationBuilder.Build();
    }
}
