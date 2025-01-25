using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;

namespace HotelServiceSystem.Application.RoomService.Commands.UpdateRoomService
{
    public record UpdateRoomServiceCommand(UpdateRoomServiceModel UpdateRoomServiceModel) : ICommand<Result>;
}
