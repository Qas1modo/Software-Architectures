using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.ProcessingRoomOrder;

public record ProcessingRoomOrderCommand(Guid RoomOrderId) : ICommand<Result>;
