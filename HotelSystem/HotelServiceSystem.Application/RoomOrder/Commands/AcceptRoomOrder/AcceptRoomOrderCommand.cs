using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.AcceptRoomOrder;

public sealed record AcceptRoomOrderCommand(Guid RoomOrderId) : ICommand<Result>;

