using FluentValidation.AspNetCore;
using AccessSystem.Application;
using AccessSystem.Infrastructure;
using Microsoft.OpenApi.Models;

namespace AccessSystem.Api;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services
            .ApplicationInstall()
            .InstallInfrastructure(configuration);

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Access System API",
                Version = "v1"
            });

        });
    }
}
