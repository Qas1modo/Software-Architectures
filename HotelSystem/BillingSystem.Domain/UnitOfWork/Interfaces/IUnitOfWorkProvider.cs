using BillingSystem.Domain.UnitOfWork.Interfaces.Base;

namespace BillingSystem.Domain.UnitOfWork.Interfaces;

public interface IUnitOfWorkProvider<TUnitOfWork> where TUnitOfWork : IBaseUnitOfWork
{
    public TUnitOfWork Create();

}
