using HotelServiceSystem.Domain.Enums;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;

public class DeclinePremiumOrderCommandHandler : ICommandHandler<DeclinePremiumOrderCommand, GenericResponseModel>
{

    public DeclinePremiumOrderCommandHandler()
    {
    }

    public async Task<GenericResponseModel> Handle(DeclinePremiumOrderCommand request, CancellationToken cancellationToken)
    {
        return new GenericResponseModel { Success = true, Message = "Order status updated to Declined" };
    }
}