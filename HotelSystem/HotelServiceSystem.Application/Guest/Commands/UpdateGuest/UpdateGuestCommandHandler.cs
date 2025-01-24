using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.Guest.Commands.UpdateGuest;

public class UpdateGuestCommandHandler : ICommandHandler<UpdateGuestCommand, GenericResponseModel>
{

    public UpdateGuestCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Guest updated successfully" };
    }
}