using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.UpdateRoomOrderCommand;

public record UpdateRoomOrderCommand(UpdateRoomOrderModel RoomOrderModel) : ICommand<Result>;

