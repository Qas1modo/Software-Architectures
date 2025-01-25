using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.ProccesingRoomOrder;

public record ProccesingRoomOrderCommand(Guid RoomOrderId) : ICommand<Result>;
