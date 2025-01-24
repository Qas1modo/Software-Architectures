using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumService.Commands.CreatePremiumService;

public class CreatePremiumServiceCommandHandler : ICommandHandler<CreatePremiumServiceCommand, GenericResponseModel>
{

    public CreatePremiumServiceCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(CreatePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Premoum service created" };
    }
}
