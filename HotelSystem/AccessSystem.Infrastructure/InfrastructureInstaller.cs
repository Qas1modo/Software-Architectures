using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using AccessSystem.Infrastructure.Databaase;
using AccessSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Core.Abstractions.Data;

namespace AccessSystem.Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey) ?? throw new Exception("Connection string not defined!");

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<AccessSystemDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AccessSystemDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AccessSystemDbContext>());
        
        services.AddScoped<IAccessCardPermissionRepository, AccessCardPermissionRepository>();
        
        services.AddScoped<IAccessCardRepository, AccessCardRepository>();
        
        services.AddScoped<IAccessCardRoleRepository, AccessCardRoleRepository>();
        
        services.AddScoped<IAccessClaimPermissionRepository, AccessClaimPermissionRepository>();
        
        services.AddScoped<IAccessClaimRepository, AccessClaimRepository>();
        
        services.AddScoped<IAccessLogEntryRepository, AccessLogEntryRepository>();
        
        services.AddScoped<IPermissionRepository, PermissionRepository>();

        services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();
        

        return services;
    }
}
