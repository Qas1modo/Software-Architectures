using Microsoft.Extensions.DependencyInjection;
using RoomManagementSystem.BL.Installers;
using RoomManagementSystem.DAL.EFCore;

namespace RoomManagementSystem.Presentation
{
    public static class PresentationInstaller
    {
        public static IServiceCollection InstallPresentation(this IServiceCollection services, string connectionString)
        {
            services.InstallDAL(connectionString);
            services.InstallBL();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
