using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;

namespace HotelServiceSystem.Application.RoomOrder.Commands.AcceptRoomOrder;

public sealed record AcceptRoomOrderCommand(Guid UserId, Guid RoomOrderId) : ICommand<GenericResponseModel>;

