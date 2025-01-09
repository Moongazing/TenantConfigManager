TenancyConfigManager

Moongazing.TenancyConfigManager is a multi-tenant configuration manager designed to support dynamic tenant-specific settings. It offers flexibility by supporting multiple data sources such as SQL Server, PostgreSQL, and JSON files, and integrates seamlessly with ASP.NET Core applications.
🚀 Features

    Multi-Data Source Support
    Supports SQL Server, PostgreSQL, and JSON-based configuration sources.
    Tenant-Based Configuration
    Enables tenant-specific settings with a fallback to shared (global) configurations.
    Shared and Specific Configuration
    Combines global and tenant-specific settings dynamically.
    Seamless ASP.NET Core Integration
    Easy to set up and use with ASP.NET Core applications.

📦 Installation

Install the package via NuGet:

dotnet add package Moongazing.TenancyConfigManager

🛠️ Usage
1. Database-Based Configuration
SQL Server

To configure SQL Server as the data source, update the Program.cs file:

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMultiTenantConfiguration(builder.Configuration, options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseMiddleware<TenantMiddleware>();

app.MapGet("/", async (HttpContext context) =>
{
    var config = context.Items["TenantConfiguration"] as IConfiguration;
    return config?["Message"] ?? "Default message";
});

app.Run();

PostgreSQL

For PostgreSQL, use the following setup:

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMultiTenantConfiguration(builder.Configuration, options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

2. JSON-Based Configuration

To use JSON files as the data source, configure the application as follows:

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITenantConfigurationService>(sp =>
    new JsonTenantConfigurationService("Configurations"));

var app = builder.Build();

app.UseMiddleware<TenantMiddleware>();

app.MapGet("/", async (HttpContext context) =>
{
    var config = context.Items["TenantConfiguration"] as IConfiguration;
    return config?["Message"] ?? "Default message";
});

app.Run();

JSON Example:
appsettings.tenant1.json:

{
    "Message": "Hello, Tenant 1!"
}

3. Database Schema

When using a database as the configuration source, create the following table:

Table Name: TenantConfigurations
Id	TenantId	Key	Value
1	tenant1	Message	Hello, Tenant 1!
2	tenant2	Message	Welcome, Tenant 2!
3	default	Message	Default Message!
🧩 Extending

    Add Caching for frequently accessed configurations using MemoryCache or DistributedCache.
    Integrate additional configuration sources like Redis or Azure App Configuration.
    Support Hierarchical Configurations for more complex multi-tenant setups.

✨ Contributing

Feel free to submit issues or pull requests to enhance the library.
📝 License

This project is licensed under the MIT License. See the LICENSE file for details.
