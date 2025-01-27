using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;
using HotelServiceSystem.Domain.Wrappers;

namespace HotelServiceSystem.Application.RoomOrder.Commands.UpdateRoomOrderCommand;

public class UpdateRoomOrderCommandHandler(IRoomServiceOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateRoomOrderCommand, Result>
{

    public async Task<Result> Handle(UpdateRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await orderRepository.UpdateRoomOrder(request.RoomOrderModel.OrderId, request.RoomOrderModel.GuestId,
            request.RoomOrderModel.ItemsToAdd, request.RoomOrderModel.ItemsToDelete);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
