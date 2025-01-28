using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Commands.DeclineRoomOrder;

public class DeclineRoomOrderCommandHandler(IUnitOfWork unitOfWork, IRoomServiceOrderRepository roomServiceOrderRepository)
    : ICommandHandler<DeclineRoomOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRoomServiceOrderRepository roomServiceOrderRepository = roomServiceOrderRepository;

    public async Task<Result> Handle(DeclineRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await roomServiceOrderRepository.DeclineRoomOrder(request.RoomOrderId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
