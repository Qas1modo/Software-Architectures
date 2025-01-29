using HotelServiceSystem.Application;
using HotelServiceSystem.Infrastructure;
using Microsoft.OpenApi.Models;

namespace HotelServiceSystem.Api;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services
            .ApplicationInstall()
            .InfrastructureInstall(configuration);

        services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Hotel Services System API",
                Version = "v1"
            });

        });
    }
}
