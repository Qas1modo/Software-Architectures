using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.DeclineRoomOrder;

public record DeclineRoomOrderCommand(Guid RoomOrderId) : ICommand<Result>;
