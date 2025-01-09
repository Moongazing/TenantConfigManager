using Microsoft.Extensions.Configuration;

namespace Moongazing.TenancyConfigManager.Services;

public interface ITenantConfigurationService
{
    Task<IConfiguration> GetConfigurationAsync(string tenantId);
}
