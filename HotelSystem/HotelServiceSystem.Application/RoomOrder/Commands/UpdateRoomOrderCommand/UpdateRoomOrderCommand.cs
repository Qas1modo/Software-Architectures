using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.RoomOrder;

namespace HotelServiceSystem.Application.RoomOrder.Commands.UpdateRoomOrderCommand;

public record UpdateRoomOrderCommand(UpdateRoomOrderModel RoomOrderModel) : ICommand<GenericResponseModel>;

