using AutoMapper;
using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItem;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

public class GetBillingItemQueryHandler (IMapper mapper, IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : IQueryHandler<GetBillingItemQuery, Maybe<BillingItemDetailModel>>
{
    public override async Task<Maybe<BillingItemDetailModel>> Handle(GetBillingItemQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var result = await unitOfWork.BillingItemRepository.GetByIdAsync(request.BillingItemId);

        return mapper.Map<BillingItemDetailModel>(result);
    }
}
