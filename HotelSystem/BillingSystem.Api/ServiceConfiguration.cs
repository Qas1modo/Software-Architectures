using BillingSystem.Application;
using BillingSystem.Infrastructure;
using Microsoft.OpenApi;

namespace BillingSystem.Api;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, string connectionString)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.ApplicationInstall()
            .InstallInfrastructure(connectionString);

        services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Billing system API",
                Version = "v1"
            });

        });
    }
}
