using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CreateRoomOrder;

public record CreateRoomOrderCommand(CreateRoomOrderModel RoomOrderModel) : ICommand<Result>;

