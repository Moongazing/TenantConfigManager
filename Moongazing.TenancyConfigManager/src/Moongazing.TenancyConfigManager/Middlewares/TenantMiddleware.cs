using Microsoft.AspNetCore.Http;
using Moongazing.TenancyConfigManager.Services;
using System.Net.Http;

namespace Moongazing.TenancyConfigManager.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate next;

    public TenantMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantConfigurationService tenantConfigurationService)
    {
        var tenantId = context.Request.Headers["X-Tenant-ID"].FirstOrDefault() ?? "default";

        var tenantConfiguration = await tenantConfigurationService.GetConfigurationAsync(tenantId);

        context.Items["TenantConfiguration"] = tenantConfiguration;

        await next(context);
    }
}