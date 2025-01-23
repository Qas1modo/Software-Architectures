using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.EFCore.QueryObjects.Base;
using BillingSystem.DAL.EFCore.QueryObjects.QueryObjectExceptions;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;

namespace BillingSystem.DAL.EFCore.QueryObjects;

public class GetBillingItemsByCustomerQueryObject : EFCoreQueryObject<BillingItemEntity>, IGetBillingItemsByCustomerQueryObject<BillingItemEntity>
{
    private bool _isFilterUsed = false;

    public GetBillingItemsByCustomerQueryObject(ApplicationDbContext dbContext) : base(dbContext) { }

    public IQueryObject<BillingItemEntity> UseFilter(int customerId) 
    {
        Filter(billingItem => billingItem.CustomerId == customerId);
        _isFilterUsed = true;
        return this;
    }

    public override Task<IEnumerable<BillingItemEntity>> ExecuteAsync()
    {
        if (!_isFilterUsed)
            throw new FilterNotUsedException("Filter was not used, use UseFilter() method first.");

        return base.ExecuteAsync();
    }
}
