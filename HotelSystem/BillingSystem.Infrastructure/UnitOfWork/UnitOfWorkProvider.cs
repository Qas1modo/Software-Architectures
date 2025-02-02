using BillingSystem.DAL.EFCore.Database;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Infrastructure.UnitOfWork.Base;

namespace BillingSystem.Infrastructure.UnitOfWork;

public class UnitOfWorkProvider : IUnitOfWorkProvider<IUnitOfWork>
{
    private readonly Func<ApplicationDbContext> _contextFactory;

    public UnitOfWorkProvider(Func<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IUnitOfWork Create()
    {
        return new BillingSystemUnitOfWork(_contextFactory());
    }
}
