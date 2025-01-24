using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.RemoveRoomService;

public class RemoveRoomServiceCommandHandler : ICommandHandler<RemoveRoomServiceCommand, GenericResponseModel>
{

    public RemoveRoomServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(RemoveRoomServiceCommand request, CancellationToken cancellationToken)
    {

        return new GenericResponseModel { Success = true, Message = "Room service removed successfully" };
    }
}