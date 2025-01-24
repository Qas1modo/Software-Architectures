using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;

public class CreatePremiumOrderCommandHandler : ICommandHandler<CreatePremiumOrderCommand, GenericResponseModel>
{

    public CreatePremiumOrderCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(CreatePremiumOrderCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Order created" };
    }
}
