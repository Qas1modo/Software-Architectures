using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Infrastructure.Database;
using HotelServiceSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelServiceSystem.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection InfrastructureInstall(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey) ?? throw new Exception("Connection string not defined!");

            services.AddSingleton(new ConnectionString(connectionString));

            services.AddDbContext<HotelServiceSystemDbContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<HotelServiceSystemDbContext>());

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<HotelServiceSystemDbContext>());

            services.AddScoped<ICleanRoomRequestRepository, CleanRoomRequestRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IGuestRepository, GuestRepository>();

            services.AddScoped<IPremiumServiceOrderRepository, PremiumServiceOrderRepository>();

            services.AddScoped<IPremiumServiceRepository, PremiumServiceRepository>();

            services.AddScoped<IRoomServiceOrderItemRepository, RoomServiceOrderItemRepository>();

            services.AddScoped<IRoomServiceOrderRepository, RoomServiceOrderRepository>();

            services.AddScoped<IRoomServiceRepository, RoomServiceRepository>();

            return services;
        }
    }
}
