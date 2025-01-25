using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.RoomService.Commands.UpdateRoomService;

public class UpdateRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateRoomServiceCommand, Result>
{
    private readonly IRoomServiceRepository roomServiceRepository = roomServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateRoomServiceCommand request, CancellationToken cancellationToken)
    {
        var roomService = await roomServiceRepository.GetByIdAsync(request.UpdateRoomServiceModel.PremiumServiceId);
        if (roomService.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceErrors.NotFound);
        }
        Result<ServiceName> serviceName = ServiceName.Create(request.UpdateRoomServiceModel.Name);
        Result<ServiceDescription> serviceDescription = ServiceDescription.Create(request.UpdateRoomServiceModel.Description);
        Result<ServiceImage> serviceImage = ServiceImage.Create(request.UpdateRoomServiceModel.Image);
        Result<Price> price = Price.Create(request.UpdateRoomServiceModel.Price);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(serviceName, serviceDescription, serviceImage, price);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }
        var updatedEntity = roomService.Value.Update(serviceName.Value, serviceDescription.Value, serviceImage.Value, price.Value);
        roomServiceRepository.Update(updatedEntity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
