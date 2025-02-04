using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItem;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

public class GetAllBillingItemsQueryHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : IQueryHandler<GetAllBillingItemsQuery, Maybe<List<BillingItemListModel>>>
{
    public async Task<Maybe<List<BillingItemListModel>>> Handle(GetAllBillingItemsQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var billingItemQuery = unitOfWork.BillingItemRepository.GetQuery();

        if (request.Page > 0 && request.PageSize > 0)
            billingItemQuery = billingItemQuery.Skip(request.Page * request.PageSize);

        var invoices = await billingItemQuery.ToListAsync();

        var result = invoices.Select(x => new BillingItemListModel() { CustomerId = x.CustomerId.Value, ItemId = x.ItemId.Value, Quantity = x.Quantity.Value, UnitPrice = x.UnitPrice.Value}).ToList();

        return result;
    }
}
