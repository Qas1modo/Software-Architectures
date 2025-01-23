using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.BL.Installers;

public static class BLInstaller
{
    public static IServiceCollection InstallBL(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(BLInstaller));

        return services;
    }
}
