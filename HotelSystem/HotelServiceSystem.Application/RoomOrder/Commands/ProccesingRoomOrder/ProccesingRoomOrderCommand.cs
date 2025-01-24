using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;

namespace HotelServiceSystem.Application.RoomOrder.Commands.ProccesingRoomOrder;

public record ProccesingRoomOrderCommand(Guid RoomOrderId) : ICommand<GenericResponseModel>;
