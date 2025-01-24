using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.RoomOrder;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CreateRoomOrder;

public record CreateRoomOrderCommand(CreateRoomOrderModel RoomOrderModel) : ICommand<GenericResponseModel>;

