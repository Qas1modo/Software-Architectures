using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;

public class DeclinePremiumOrderCommandHandler : ICommandHandler<DeclinePremiumOrderCommand, Result>
{

    public DeclinePremiumOrderCommandHandler()
    {
    }

    public async Task<Result> Handle(DeclinePremiumOrderCommand request, CancellationToken cancellationToken)
    {
        return Result.Success();
    }
}