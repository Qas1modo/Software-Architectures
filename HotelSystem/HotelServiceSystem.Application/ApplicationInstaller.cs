using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HotelServiceSystem.Application;

public static class ApplicationInstaller
{
    public static IServiceCollection ApplicationInstall(this IServiceCollection services)
    {
        services.AddMediatR(new MediatRServiceConfiguration()
            .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
