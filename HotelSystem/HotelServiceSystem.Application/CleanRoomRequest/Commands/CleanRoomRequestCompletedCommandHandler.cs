using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.CleanRoomRequest.Commands;

public class CleanRoomRequestCompletedCommandHandler(ICleanRoomRequestRepository cleanRoomRequestRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CleanRoomRequestCompletedCommand, Result>
{
    public async Task<Result> Handle(CleanRoomRequestCompletedCommand request, CancellationToken cancellationToken)
    {
        var result = await cleanRoomRequestRepository.MarkAsCompleted(request.RequestId);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
