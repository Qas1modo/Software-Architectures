using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.RoomService.Commands.DeleteRoomService
{
    public record DeleteRoomServiceCommand(DeleteRoomServiceModel DeleteRoomServiceModel) : ICommand<Result>;
}
