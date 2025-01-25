using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomService.Commands.DeleteRoomService;

public class DeleteRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteRoomServiceCommand, Result>
{
    private readonly IRoomServiceRepository roomServiceRepository = roomServiceRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteRoomServiceCommand request, CancellationToken cancellationToken)
    {
        var roomService = await roomServiceRepository.GetByIdAsync(request.DeleteRoomServiceModel.PremiumServiceId);
        if (roomService.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoomServiceErrors.NotFound);
        }
        roomServiceRepository.Remove(roomService);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}