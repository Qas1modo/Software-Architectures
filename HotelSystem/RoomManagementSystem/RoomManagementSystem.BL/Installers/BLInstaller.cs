using Microsoft.Extensions.DependencyInjection;


namespace RoomManagementSystem.BL.Installers
{
    public static class BLInstaller
    {
        public static IServiceCollection InstallBL(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(BLInstaller));

            return services;
        }
    }
}
