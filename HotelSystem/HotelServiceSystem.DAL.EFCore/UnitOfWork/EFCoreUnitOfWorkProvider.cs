using HotelServiceSystem.DAL.EFCore.UnitOfWork.Base;
using HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using HotelServiceSystem.DAL.EFCore.Database;

namespace HotelServiceSystem.DAL.EFCore.UnitOfWork;

public class EFCoreUnitOfWorkProvider : IUnitOfWorkProvider<IEFCoreUnitOfWork>
{
    private readonly Func<ApplicationDbContext> _contextFactory;

    public EFCoreUnitOfWorkProvider(Func<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEFCoreUnitOfWork Create()
    {
        return new EFCoreUnitOfWork(_contextFactory());
    }
}
