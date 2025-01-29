using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.PremiumService.Commands.CreatePremiumService;

public class CreatePremiumServiceCommandHandler(IPremiumServiceRepository premiumServiceRepository,
               IUnitOfWork unitOfWork) : ICommandHandler<CreatePremiumServiceCommand, Result>
{
    private readonly IPremiumServiceRepository premiumServiceRepository = premiumServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreatePremiumServiceCommand request, CancellationToken cancellationToken)
    {
        Result<ServiceName> serviceName = ServiceName.Create(request.CreatePremiumServiceModel.Name);
        Result<ServiceDescription> serviceDescription = ServiceDescription.Create(request.CreatePremiumServiceModel.Description);
        Result<ServiceImage> serviceImage = ServiceImage.Create(request.CreatePremiumServiceModel.Image);
        Result<Price> price = Price.Create(request.CreatePremiumServiceModel.Price);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(serviceName, serviceDescription, serviceImage, price);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }

        var premiumService = PremiumServiceEntity.Create(serviceName.Value, serviceDescription.Value,
            serviceImage.Value, price.Value, request.CreatePremiumServiceModel.RelevantRoleCodeName);
        premiumServiceRepository.Insert(premiumService);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
