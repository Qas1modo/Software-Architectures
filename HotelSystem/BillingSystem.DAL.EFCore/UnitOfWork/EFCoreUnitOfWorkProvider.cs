using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.UnitOfWork.Base;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;

namespace BillingSystem.DAL.EFCore.UnitOfWork;

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
