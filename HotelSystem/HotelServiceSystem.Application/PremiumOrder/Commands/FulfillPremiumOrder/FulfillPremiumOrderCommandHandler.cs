using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public class FulfillPremiumOrderCommandHandler : ICommandHandler<FulfillPremiumOrderCommand, GenericResponseModel>
{

    public FulfillPremiumOrderCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(FulfillPremiumOrderCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Order status updated to Declined" };
    }
}