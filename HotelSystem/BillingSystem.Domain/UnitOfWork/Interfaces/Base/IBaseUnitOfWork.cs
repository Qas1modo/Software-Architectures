namespace BillingSystem.Domain.UnitOfWork.Interfaces.Base;

public interface IBaseUnitOfWork : IDisposable
{
    Task Commit();
}
