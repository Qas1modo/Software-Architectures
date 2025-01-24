using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.Guest.Commands.CreateGuest;

public class CreateGuestCommandHandler : ICommandHandler<CreateGuestCommand, GenericResponseModel>
{

    public CreateGuestCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Guest created" };
    }
}
