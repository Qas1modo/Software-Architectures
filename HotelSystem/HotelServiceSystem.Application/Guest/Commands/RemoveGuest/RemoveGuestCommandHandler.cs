using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.Guest.Commands.RemoveGuest;

public class RemoveGuestCommandHandler : ICommandHandler<RemoveGuestCommand, GenericResponseModel>
{

    public RemoveGuestCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(RemoveGuestCommand request, CancellationToken cancellationToken)
    {

        return new GenericResponseModel { Success = true, Message = "Guest removed successfully" };
    }
}