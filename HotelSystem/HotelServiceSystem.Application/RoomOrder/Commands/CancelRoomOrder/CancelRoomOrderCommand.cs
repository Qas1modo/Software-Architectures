using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.RoomOrder;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CancelRoomOrder;

public record CancelRoomOrderCommand(CancelRoomOrderModel CancelRoomOrderModel) : ICommand<GenericResponseModel>;

