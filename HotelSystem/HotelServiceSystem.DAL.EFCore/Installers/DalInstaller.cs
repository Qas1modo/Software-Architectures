using HotelServiceSystem.DAL.EFCore.QueryObjects;
using HotelServiceSystem.DAL.EFCore.UnitOfWork;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotelServiceSystem.DAL.EFCore.QueryObjects.Base;
using HotelServiceSystem.DAL.EFCore.Database;
using HotelServiceSystem.DAL.EFCore.Entities;

namespace HotelServiceSystem.DAL.Installers;

public static class DalInstaller
{
    public static IServiceCollection DalInstall(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        

        services.AddScoped<IUnitOfWorkProvider<IEFCoreUnitOfWork>, EFCoreUnitOfWorkProvider>((services) =>
        {
            return new EFCoreUnitOfWorkProvider(new Func<ApplicationDbContext>(() => services.GetRequiredService<ApplicationDbContext>()));
        });

        services.AddTransient<IGetFulfilledOrdersForGuestQueryObject<PremiumServiceOrderEntity>, GetFulfilledPremiumOrdersForGuestQueryObject>();
        services.AddTransient<IGetAllRoomServiceItemsQueryObject<RoomServiceItemEntity>, GetAllRoomServiceItemsQueryObject>();

        services.AddTransient(typeof(IQueryObject<>), typeof(EFCoreQueryObject<>));

        return services;
    }
}
