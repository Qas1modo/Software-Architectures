using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BillingSystem.Application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection ApplicationInstall(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationInstaller));

            services.AddMediatR(new MediatRServiceConfiguration()
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
