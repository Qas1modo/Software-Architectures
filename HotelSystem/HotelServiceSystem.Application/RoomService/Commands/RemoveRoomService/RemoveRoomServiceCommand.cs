using HotelServiceSystem.Contracts.Models.RoomService;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.RemoveRoomService
{
    public record RemoveRoomServiceCommand(RemoveRoomServiceModel CancelRoomOrderModel) : ICommand<GenericResponseModel>;
}
