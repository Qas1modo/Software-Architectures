using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomOrder.Commands.AcceptRoomOrder;

public class AcceptRoomOrderCommandHandler(IUnitOfWork unitOfWork, IRoomServiceOrderRepository roomServiceOrderRepository) 
    : ICommandHandler<AcceptRoomOrderCommand, Result>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRoomServiceOrderRepository roomServiceOrderRepository = roomServiceOrderRepository;

    public async Task<Result> Handle(AcceptRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await roomServiceOrderRepository.AcceptRoomOrder(request.RoomOrderId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
