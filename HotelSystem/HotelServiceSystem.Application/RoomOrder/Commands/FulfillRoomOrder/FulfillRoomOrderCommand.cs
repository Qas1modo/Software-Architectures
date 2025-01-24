using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;

namespace HotelServiceSystem.Application.RoomOrder.Commands.FulfillRoomOrder;

public record FulfillRoomOrderCommand(Guid RoomOrderId) : ICommand<GenericResponseModel>;