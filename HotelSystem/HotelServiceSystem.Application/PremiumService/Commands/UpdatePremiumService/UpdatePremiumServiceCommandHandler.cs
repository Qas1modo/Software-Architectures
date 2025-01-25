using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.PremiumService.Commands.UpdatePremiumService;

public class UpdatePremiumServiceCommandHandler(IPremiumServiceRepository premiumServiceRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdatePremiumServiceCommand, Result>
{
    private readonly IPremiumServiceRepository premiumServiceRepository = premiumServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdatePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        var premiumService = await premiumServiceRepository.GetByIdAsync(request.UpdatePremiumServiceModel.PremiumServiceId);
        if (premiumService.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceErrors.NotFound);
        }
        Result<ServiceName> serviceName = ServiceName.Create(request.UpdatePremiumServiceModel.Name);
        Result<ServiceDescription> serviceDescription = ServiceDescription.Create(request.UpdatePremiumServiceModel.Description);
        Result<ServiceImage> serviceImage = ServiceImage.Create(request.UpdatePremiumServiceModel.Image);
        Result<Price> price = Price.Create(request.UpdatePremiumServiceModel.Price);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(serviceName, serviceDescription, serviceImage, price);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }
        var updatedEntity = premiumService.Value.Update(serviceName.Value, serviceDescription.Value,
            serviceImage.Value, price.Value, request.UpdatePremiumServiceModel.RelevantRoleCodeName);
        premiumServiceRepository.Update(updatedEntity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}