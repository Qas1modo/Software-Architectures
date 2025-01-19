using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

namespace BillingSystem.DAL.EFCore.UnitOfWork;

public interface IEFCoreUnitOfWork : IUnitOfWork
{
    // public IEntityRepository<?Entity> ?Repository { get; }
    // ...
}
