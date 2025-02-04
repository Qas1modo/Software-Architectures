using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItem;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

public class GetBillingItemByCustomerQueryHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : IQueryHandler<GetBillingItemsByCustomerQuery, Maybe<List<BillingItemListModel>>>
{
    public async Task<Maybe<List<BillingItemListModel>>> Handle(GetBillingItemsByCustomerQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var billingItemQuery = unitOfWork.BillingItemRepository.GetQuery();

        var billingItems = await billingItemQuery.Where(x => x.CustomerId.Value == request.CustomerId).ToListAsync();

        var result = billingItems.Select(x => new BillingItemListModel() { CustomerId = x.CustomerId.Value, ItemId = x.ItemId.Value, UnitPrice = x.UnitPrice.Value, Quantity = x.Quantity.Value }).ToList();

        return result;
    }
}
