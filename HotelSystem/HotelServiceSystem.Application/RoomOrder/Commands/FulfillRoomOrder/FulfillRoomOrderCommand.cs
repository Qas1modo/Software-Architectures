using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.FulfillRoomOrder;

public record FulfillRoomOrderCommand(Guid RoomOrderId) : ICommand<Result>;