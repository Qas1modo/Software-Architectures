using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Commands.FulfillRoomOrder;

public class FulfillRoomOrderCommandHandler(IUnitOfWork unitOfWork, IRoomServiceOrderRepository roomServiceOrderRepository) 
    : ICommandHandler<FulfillRoomOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRoomServiceOrderRepository roomServiceOrderRepository = roomServiceOrderRepository;

    public async Task<Result> Handle(FulfillRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await roomServiceOrderRepository.FulfillRoomOrder(request.RoomOrderId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
