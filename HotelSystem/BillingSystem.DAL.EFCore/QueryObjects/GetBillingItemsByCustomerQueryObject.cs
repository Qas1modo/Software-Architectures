using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.QueryObjects.Base;
using BillingSystem.DAL.EFCore.QueryObjects.QueryObjectExceptions;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using BillingSystem.Domain.Entities.BillingItem;

namespace BillingSystem.DAL.EFCore.QueryObjects;

public class GetBillingItemsByCustomerQueryObject : EFCoreQueryObject<BillingItem>, IGetBillingItemsByCustomerQueryObject<BillingItem>
{
    private bool _isFilterUsed = false;

    public GetBillingItemsByCustomerQueryObject(ApplicationDbContext dbContext) : base(dbContext) { }

    public IQueryObject<BillingItem> UseFilter(Guid customerId) 
    {
        Filter(billingItem => billingItem.CustomerId.Value == customerId);
        _isFilterUsed = true;
        return this;
    }

    public override Task<IEnumerable<BillingItem>> ExecuteAsync()
    {
        if (!_isFilterUsed)
            throw new FilterNotUsedException("Filter was not used, use UseFilter() method first.");

        return base.ExecuteAsync();
    }
}
