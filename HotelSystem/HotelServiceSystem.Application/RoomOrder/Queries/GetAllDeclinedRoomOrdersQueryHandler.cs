using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

internal sealed class GetAllDeclinedRoomOrdersQueryHandler(IRoomServiceOrderRepository roomOrderRepository)
    : IQueryHandler<GetAllDeclinedRoomOrdersQuery, Maybe<List<RoomOrderResponseModel>>>
{

    public async Task<Maybe<List<RoomOrderResponseModel>>> Handle(GetAllDeclinedRoomOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await roomOrderRepository.GetDeclinedOrdersForGuestAsync(request.GuestId, cancellationToken);
    }
}