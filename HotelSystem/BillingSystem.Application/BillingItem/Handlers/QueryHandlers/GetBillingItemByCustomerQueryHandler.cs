using AutoMapper;
using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItem;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

public class GetBillingItemByCustomerQueryHandler (IMapper mapper, IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : IQueryHandler<GetBillingItemsByCustomerQuery, Maybe<List<BillingItemListModel>>>
{
    public override async Task<Maybe<List<BillingItemListModel>>> Handle(GetBillingItemsByCustomerQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var billingItemQuery = unitOfWork.BillingItemRepository.GetQuery();

        var billingItems = await billingItemQuery.Where(x => x.CustomerId.Value == request.CustomerId).ToListAsync();
        return mapper.Map<ICollection<BillingItemListModel>>(billingItems).ToList();
    }
}
