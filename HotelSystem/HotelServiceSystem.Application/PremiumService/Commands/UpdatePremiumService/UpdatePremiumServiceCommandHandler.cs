using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumService.Commands.UpdatePremiumService;

public class UpdatePremiumServiceCommandHandler : ICommandHandler<UpdatePremiumServiceCommand, GenericResponseModel>
{

    public UpdatePremiumServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(UpdatePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Premium service updated successfully" };
    }
}