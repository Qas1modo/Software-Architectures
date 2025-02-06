using Microsoft.OpenApi.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace RoomManagementSystem.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllers();

            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Room management system API",
                    Version = "v1"
                });

            });
        }
    }
}
