using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CancelRoomOrder;

public class CancelRoomOrderCommandHandler(IUnitOfWork unitOfWork, IRoomServiceOrderRepository roomServiceOrderRepository) 
    : ICommandHandler<CancelRoomOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRoomServiceOrderRepository roomServiceOrderRepository = roomServiceOrderRepository;

    public async Task<Result> Handle(CancelRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await roomServiceOrderRepository.CancelRoomOrder(request.OrderId, request.GuestId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
