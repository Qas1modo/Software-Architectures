using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.RoomService.Commands.CreateRoomService;

public class CreateRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateRoomServiceCommand, Result>
{
    private readonly IRoomServiceRepository roomServiceRepository = roomServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateRoomServiceCommand request, CancellationToken cancellationToken)
    {
        Result<ServiceName> serviceName = ServiceName.Create(request.CreateRoomOrderModel.Name);
        Result<ServiceDescription> serviceDescription = ServiceDescription.Create(request.CreateRoomOrderModel.Description);
        Result<ServiceImage> serviceImage = ServiceImage.Create(request.CreateRoomOrderModel.Image);
        Result<Price> price = Price.Create(request.CreateRoomOrderModel.Price);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(serviceName, serviceDescription, serviceImage, price);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }

        var roomService = RoomServiceEntity.Create(serviceName.Value, serviceDescription.Value, serviceImage.Value, price.Value);
        roomServiceRepository.Insert(roomService);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
