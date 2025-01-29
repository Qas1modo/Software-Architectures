using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;

public class DeclinePremiumOrderCommandHandler(IPremiumServiceOrderRepository premiumServiceOrderRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeclinePremiumOrderCommand, Result>
{
    private readonly IPremiumServiceOrderRepository premiumServiceOrderRepository = premiumServiceOrderRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeclinePremiumOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await premiumServiceOrderRepository.DeclinePremiumOrder(request.PremiumOrderId);
        if (result.IsSuccess)
        {
            if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return result;
    }
}