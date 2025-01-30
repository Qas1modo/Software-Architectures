using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

namespace BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;

public interface IUnitOfWorkProvider<TUnitOfWork> where TUnitOfWork : IUnitOfWork
{
    public TUnitOfWork Create();

}
