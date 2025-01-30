using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.QueryObjects;
using BillingSystem.DAL.EFCore.QueryObjects.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Domain.Entities.BillingItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.DAL.EFCore.Installers;

public static class DalInstaller
{
    public static IServiceCollection InstallDAL(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });


        services.AddScoped<IUnitOfWorkProvider<IEFCoreUnitOfWork>, EFCoreUnitOfWorkProvider>((services) =>
        {
            return new EFCoreUnitOfWorkProvider(new Func<ApplicationDbContext>(() => services.GetRequiredService<ApplicationDbContext>()));
        });

        services.AddTransient<IGetBillingItemsByCustomerQueryObject<BillingItem>, GetBillingItemsByCustomerQueryObject>();

        services.AddTransient(typeof(IQueryObject<>), typeof(EFCoreQueryObject<>));

        return services;
    }
}
