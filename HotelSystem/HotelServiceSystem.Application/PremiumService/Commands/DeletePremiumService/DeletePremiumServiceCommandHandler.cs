using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumService.Commands.DeletePremiumService;

public class DeletePremiumServiceCommandHandler(IPremiumServiceRepository premiumServiceRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeletePremiumServiceCommand, Result>
{
    private readonly IPremiumServiceRepository premiumServiceRepository = premiumServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeletePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        var premiumService = await premiumServiceRepository.GetByIdAsync(request.DeletePremiumServiceModel.PremiumServiceId);
        if (premiumService.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceErrors.NotFound);
        }
        premiumServiceRepository.Remove(premiumService);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}