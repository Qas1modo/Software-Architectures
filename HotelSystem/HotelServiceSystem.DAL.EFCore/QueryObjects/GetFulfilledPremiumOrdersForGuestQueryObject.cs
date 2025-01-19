using HotelServiceSystem.DAL.EFCore.QueryObjects.Base;
using HotelServiceSystem.DAL.EFCore.Database;
using HotelServiceSystem.DAL.EFCore.Entities;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using HotelServiceSystem.DAL.EFCore.QueryObjects.QueryObjectExceptions;

namespace HotelServiceSystem.DAL.EFCore.QueryObjects;

public class GetFulfilledPremiumOrdersForGuestQueryObject : EFCoreQueryObject<PremiumServiceOrderEntity>, IGetFulfilledOrdersForGuestQueryObject<PremiumServiceOrderEntity>
{
    private bool _isFilterUsed = false;

    public GetFulfilledPremiumOrdersForGuestQueryObject(ApplicationDbContext dbContext) : base(dbContext) { }

    public IQueryObject<PremiumServiceOrderEntity> UseFilter(Guid userId)
    {
        Filter(order => order.GuestId == userId);
        _isFilterUsed = true;
        return this;
    }

    public override Task<IEnumerable<PremiumServiceOrderEntity>> ExecuteAsync()
    {
        if (!_isFilterUsed)
            throw new FilterNotUsedException("Filter was not used, use UseFilter() method first.");

        return base.ExecuteAsync();
    }
}