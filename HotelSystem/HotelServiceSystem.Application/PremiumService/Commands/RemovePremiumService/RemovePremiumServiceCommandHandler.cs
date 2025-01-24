using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumService.Commands.RemovePremiumService;

public class RemovePremiumServiceCommandHandler : ICommandHandler<RemovePremiumServiceCommand, GenericResponseModel>
{

    public RemovePremiumServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(RemovePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Premium service removed successfully" };
    }
}