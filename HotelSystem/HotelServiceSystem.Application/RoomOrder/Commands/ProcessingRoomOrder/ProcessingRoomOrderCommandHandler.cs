using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Commands.ProcessingRoomOrder;

public class ProcessingRoomOrderCommandHandler(IUnitOfWork unitOfWork, IRoomServiceOrderRepository roomServiceOrderRepository)
    : ICommandHandler<ProcessingRoomOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRoomServiceOrderRepository roomServiceOrderRepository = roomServiceOrderRepository;

    public async Task<Result> Handle(ProcessingRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await roomServiceOrderRepository.ProcessingRoomOrder(request.RoomOrderId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
