using BillingSystem.DAL.EFCore.Installers;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Presentation;

public static class PresentationInstaller
{
    public static IServiceCollection InstallPresentation(this IServiceCollection services, string connectionString)
    {
        services.InstallDAL(connectionString);
        // services.InstallBL();
        //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
