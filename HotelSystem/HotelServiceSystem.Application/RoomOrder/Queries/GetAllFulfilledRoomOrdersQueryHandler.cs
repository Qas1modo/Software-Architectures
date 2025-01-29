using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

internal sealed class GetAllFulfilledRoomOrdersQueryHandler(IRoomServiceOrderRepository roomOrderRepository)
    : IQueryHandler<GetAllFulfilledRoomOrdersQuery, Maybe<List<RoomOrderResponseModel>>>
{

    public async Task<Maybe<List<RoomOrderResponseModel>>> Handle(GetAllFulfilledRoomOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await roomOrderRepository.GetFulfilledOrdersForGuestAsync(request.GuestId, cancellationToken);
    }
}