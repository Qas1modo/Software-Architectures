using AutoMapper;
using BillingSystem.BL.Handlers.QueryHandlers.Base;
using BillingSystem.BL.Queries.BillingItemQueries;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Handlers.QueryHandlers.BillingItemQueryHandlers;

public class GetBillingItemByCustomerQueryHandler : QueryHandler<GetBillingItemsByCustomerQuery, List<BillingItemListModel>>, IRequestHandler<GetBillingItemsByCustomerQuery, List<BillingItemListModel>>
{
    private IGetBillingItemsByCustomerQueryObject<BillingItemEntity> _getBillingItemByCustomerQueryObject;

    public GetBillingItemByCustomerQueryHandler(IGetBillingItemsByCustomerQueryObject<BillingItemEntity> getBillingItemByCustomerQueryObject, IMapper mapper) : base(mapper)
    {
        _getBillingItemByCustomerQueryObject = getBillingItemByCustomerQueryObject;
    }

    public override async Task<List<BillingItemListModel>> Handle(GetBillingItemsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var billingItems = await _getBillingItemByCustomerQueryObject.UseFilter(request.CustomerId).ExecuteAsync();
        return _mapper.Map<ICollection<BillingItemListModel>>(billingItems).ToList();
    }
}
