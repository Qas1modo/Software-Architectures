using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

internal sealed class GetAllCanceledRoomOrdersQueryHandler(IRoomServiceOrderRepository roomOrderRepository)
    : IQueryHandler<GetAllCanceledRoomOrdersQuery, Maybe<List<RoomOrderResponseModel>>>
{

    public async Task<Maybe<List<RoomOrderResponseModel>>> Handle(GetAllCanceledRoomOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await roomOrderRepository.GetCanceledOrdersForGuestAsync(request.GuestId, cancellationToken);
    }
}