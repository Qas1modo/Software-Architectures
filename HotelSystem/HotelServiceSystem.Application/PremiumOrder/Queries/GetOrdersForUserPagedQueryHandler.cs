using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumOrder.Queries;

internal sealed class GetOrdersForUserPagedQueryHandler(IPremiumServiceOrderRepository premiumOrderServiceRepository)
    : IQueryHandler<GetOrdersForUserPagedQuery, Maybe<PagedList<PremiumOrderResponseModel>>>
{

    public async Task<Maybe<PagedList<PremiumOrderResponseModel>>> Handle(GetOrdersForUserPagedQuery request,
        CancellationToken cancellationToken)
    {
        return await premiumOrderServiceRepository.GetOrdersForUserAsync(request.GetPremiumServiceModel, cancellationToken);
    }
}