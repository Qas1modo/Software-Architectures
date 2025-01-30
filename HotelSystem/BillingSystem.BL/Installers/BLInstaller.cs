using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Application.Installers;

public static class BLInstaller
{
    public static IServiceCollection InstallBL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BLInstaller));

        return services;
    }
}
