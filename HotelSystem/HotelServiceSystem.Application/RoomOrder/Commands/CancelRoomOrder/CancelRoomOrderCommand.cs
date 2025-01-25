using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CancelRoomOrder;

public record CancelRoomOrderCommand(CancelRoomOrderModel CancelRoomOrderModel) : ICommand<Result>;

