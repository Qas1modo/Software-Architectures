using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace HotelServiceSystem.Application;

public static class ApplicationInstaller
{
    public static IServiceCollection ApplicationInstall(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(new MediatRServiceConfiguration()
            .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
