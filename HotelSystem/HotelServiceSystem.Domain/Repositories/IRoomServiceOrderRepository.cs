using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Wrappers;

namespace HotelServiceSystem.Domain.Repositories;

public interface IRoomServiceOrderRepository
{
    Task<Maybe<RoomServiceOrderEntity>> GetByIdAsync(Guid id);
    Task<Result> CreateOrder(GuestEntity guest, IEnumerable<RoomOrderCreateDatabaseModel> orderItems);
    Task<Result> CancelRoomOrder(Guid RoomOrderId, Guid GuestId);
    Task<Result> UpdateRoomOrder(Guid OrderId, Guid GuestId, IEnumerable<RoomOrderItemModel> ItemsToAdd,
        IEnumerable<RoomOrderItemModel> ItemsToDelete);
    Task<Result> AcceptRoomOrder(Guid RoomOrderId);
    Task<Result> ProcessingRoomOrder(Guid RoomOrderId);
    Task<Result> FulfillRoomOrder(Guid RoomOrderId);

}
