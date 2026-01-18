using Microsoft.OpenApi;

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
