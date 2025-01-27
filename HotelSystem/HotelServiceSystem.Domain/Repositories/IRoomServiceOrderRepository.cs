using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Wrappers;
using System.Threading;

namespace HotelServiceSystem.Domain.Repositories;

public interface IRoomServiceOrderRepository
{
    Task<Maybe<RoomServiceOrderEntity>> GetByIdAsync(Guid id);
    Task<Maybe<List<RoomOrderResponseModel>>> GetNewOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken);
    Task<Maybe<List<RoomOrderResponseModel>>> GetCanceledOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken);
    Task<Maybe<List<RoomOrderResponseModel>>> GetAcceptedOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken);
    Task<Maybe<List<RoomOrderResponseModel>>> GetDeclinedOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken);
    Task<Maybe<List<RoomOrderResponseModel>>> GetFulfilledOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken);
    Task<Result> CreateOrder(GuestEntity guest, IEnumerable<RoomOrderCreateDatabaseModel> orderItems);
    Task<Result> CancelRoomOrder(Guid RoomOrderId, Guid GuestId);
    Task<Result> UpdateRoomOrder(Guid OrderId, Guid GuestId, IEnumerable<RoomOrderItemModel> ItemsToAdd,
        IEnumerable<RoomOrderItemModel> ItemsToDelete);
    Task<Result> AcceptRoomOrder(Guid RoomOrderId);
    Task<Result> DeclineRoomOrder(Guid RoomOrderId);
    Task<Result> FulfillRoomOrder(Guid RoomOrderId);

}
