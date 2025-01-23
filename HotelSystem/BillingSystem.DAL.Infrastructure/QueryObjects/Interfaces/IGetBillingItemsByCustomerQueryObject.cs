using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;

namespace BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces;

public interface IGetBillingItemsByCustomerQueryObject<TEntity> : IQueryObject<TEntity> where TEntity : class, new()
{
    IQueryObject<TEntity> UseFilter(int customerId);
}
