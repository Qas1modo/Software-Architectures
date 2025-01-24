using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.CreateRoomService;

public class CreateRoomServiceCommandHandler : ICommandHandler<CreateRoomServiceCommand, GenericResponseModel>
{

    public CreateRoomServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(CreateRoomServiceCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Room service created" };
    }
}
