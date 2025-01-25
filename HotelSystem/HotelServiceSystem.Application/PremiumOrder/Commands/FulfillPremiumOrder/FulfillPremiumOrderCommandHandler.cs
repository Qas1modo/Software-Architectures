using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public class FulfillPremiumOrderCommandHandler : ICommandHandler<FulfillPremiumOrderCommand, Result>
{

    public FulfillPremiumOrderCommandHandler()
    {
    }

    public async Task<Result> Handle(FulfillPremiumOrderCommand request, CancellationToken cancellationToken)
    {
        return Result.Success();
    }
}