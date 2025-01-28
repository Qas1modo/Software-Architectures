using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

internal sealed class GetAllAcceptedRoomOrdersQueryHandler(IRoomServiceOrderRepository roomOrderRepository)
    : IQueryHandler<GetAllAcceptedRoomOrdersQuery, Maybe<List<RoomOrderResponseModel>>>
{

    public async Task<Maybe<List<RoomOrderResponseModel>>> Handle(GetAllAcceptedRoomOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await roomOrderRepository.GetAcceptedOrdersForGuestAsync(request.GuestId, cancellationToken);
    }
}