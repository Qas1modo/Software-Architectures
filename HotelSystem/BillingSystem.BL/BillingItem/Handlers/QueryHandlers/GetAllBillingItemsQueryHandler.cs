using AutoMapper;
using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

public class GetAllBillingItemsQueryHandler : QueryHandler<GetAllBillingItemsQuery, List<BillingItemListModel>>, IRequestHandler<GetAllBillingItemsQuery, List<BillingItemListModel>>
{
    private readonly IQueryObject<BillingItemEntity> _billingItemQueryObject;

    public GetAllBillingItemsQueryHandler(IMapper mapper, IQueryObject<BillingItemEntity> billingItemQueryObject) : base(mapper)
    {
        _billingItemQueryObject = billingItemQueryObject;
    }

    public override async Task<List<BillingItemListModel>> Handle(GetAllBillingItemsQuery request, CancellationToken cancellationToken)
    {
        if (request.Page > 0 && request.PageSize > 0)
            _billingItemQueryObject.Page(request.Page, request.PageSize);

        var billingItems = await _billingItemQueryObject.ExecuteAsync();
        return _mapper.Map<ICollection<BillingItemListModel>>(billingItems).ToList();
    }
}
