using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.UpdateRoomService;

public class UpdateRoomServiceCommandHandler : ICommandHandler<UpdateRoomServiceCommand, GenericResponseModel>
{

    public UpdateRoomServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(UpdateRoomServiceCommand request, CancellationToken cancellationToken)
    {

        return new GenericResponseModel { Success = true, Message = "Room service updated successfully" };
    }
}
