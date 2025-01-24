using HotelServiceSystem.Contracts.Models.RoomService;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.UpdateRoomService
{
    public record UpdateRoomServiceCommand(UpdateRoomServiceModel UpdateRoomServiceModel) : ICommand<GenericResponseModel>;
}
