using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.Guest.Queries;

internal sealed class GetAllGuestsQueryHandler(IGuestRepository guestRepository)
    : IQueryHandler<GetAllGuestsQuery, Maybe<PagedList<GuestResponseModel>>>
{

    public async Task<Maybe<PagedList<GuestResponseModel>>> Handle(GetAllGuestsQuery request,
        CancellationToken cancellationToken)
    {
        return await guestRepository.GetGuestsAsync(request.GetPremiumServiceModel, cancellationToken);
    }
}