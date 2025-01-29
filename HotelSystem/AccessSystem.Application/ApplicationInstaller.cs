using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AccessSystem.Application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection ApplicationInstall(this IServiceCollection services)
        {
            services.AddMediatR(new MediatRServiceConfiguration()
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
