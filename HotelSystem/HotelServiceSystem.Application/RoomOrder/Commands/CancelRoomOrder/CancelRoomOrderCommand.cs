using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CancelRoomOrder;

public record CancelRoomOrderCommand(Guid OrderId, Guid GuestId) : ICommand<Result>;

