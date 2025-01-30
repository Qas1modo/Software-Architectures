
using RoomManagementSystem.DAL.EFCore.Database;
using RoomManagementSystem.DAL.EFCore.UnitOfWork.Base;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.DAL.EFCore.UnitOfWork;

public class EFCoreUnitOfWorkProvider : IUnitOfWorkProvider<IEFCoreUnitOfWork>
{
    private readonly Func<RoomManagementDbContext> _contextFactory;

    public EFCoreUnitOfWorkProvider(Func<RoomManagementDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEFCoreUnitOfWork Create()
    {
        return new EFCoreUnitOfWork(_contextFactory());
    }
}
