using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoomManagementSystem.DAL.EFCore.Database;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.EFCore
{
    public static class DALInstaller
    {
        public static IServiceCollection InstallDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RoomManagementDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });


            services.AddScoped<IUnitOfWorkProvider<IEFCoreUnitOfWork>, EFCoreUnitOfWorkProvider>((services) =>
            {
                return new EFCoreUnitOfWorkProvider(new Func<RoomManagementDbContext>(() => services.GetRequiredService<RoomManagementDbContext>()));
            });

            return services;
        }
    }
}
