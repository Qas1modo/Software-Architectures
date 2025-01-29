using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

internal sealed class GetAllNewRoomOrdersQueryHandler(IRoomServiceOrderRepository roomOrderRepository)
    : IQueryHandler<GetAllNewRoomOrdersQuery, Maybe<List<RoomOrderResponseModel>>>
{

    public async Task<Maybe<List<RoomOrderResponseModel>>> Handle(GetAllNewRoomOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await roomOrderRepository.GetNewOrdersForGuestAsync(request.GuestId, cancellationToken);
    }
}