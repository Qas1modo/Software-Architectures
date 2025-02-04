using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Infrastructure.Database;
using BillingSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });


        services.AddScoped<IUnitOfWorkProvider<IUnitOfWork>, UnitOfWorkProvider>((services) =>
        {
            return new UnitOfWorkProvider(new Func<ApplicationDbContext>(() => services.GetRequiredService<ApplicationDbContext>()));
        });

        return services;
    }
}
