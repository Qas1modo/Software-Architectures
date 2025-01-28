using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.CleanRoomRequest.Commands;

public class CreateCleanRoomRequestCommandHandler(ICleanRoomRequestRepository cleanRoomRequestRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCleanRoomRequestCommand, Result>
{
    public async Task<Result> Handle(CreateCleanRoomRequestCommand request, CancellationToken cancellationToken)
    {
        Result<RoomNumber> roomNumber = RoomNumber.Create(request.RoomNumber);
        if (roomNumber.IsFailure)
        {
            return roomNumber;
        }
        var cleanRoomRequest = CleanRoomRequestEntity.Create(roomNumber.Value);
        cleanRoomRequestRepository.Insert(cleanRoomRequest);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
