using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;

public class DeactivateGuestCommandHandler : ICommandHandler<DeactivateGuestCommand, GenericResponseModel>
{

    public DeactivateGuestCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(DeactivateGuestCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Guest updated to inactive" };
    }
}