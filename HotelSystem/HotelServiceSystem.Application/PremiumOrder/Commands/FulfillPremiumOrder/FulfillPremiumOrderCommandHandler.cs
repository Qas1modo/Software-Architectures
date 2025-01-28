using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public class FulfillPremiumOrderCommandHandler(IUnitOfWork unitOfWork, IPremiumServiceOrderRepository premiumServiceOrderRepository)
    : ICommandHandler<FulfillPremiumOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPremiumServiceOrderRepository premiumServiceOrderRepository = premiumServiceOrderRepository;

    public async Task<Result> Handle(FulfillPremiumOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await premiumServiceOrderRepository.FulfillPremiumOrder(request.PremiumOrderId);
        if (result.IsSuccess)
        {
            if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return result;
    }
}