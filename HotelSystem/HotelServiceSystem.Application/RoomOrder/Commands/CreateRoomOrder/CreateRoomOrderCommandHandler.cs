using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;
using HotelServiceSystem.Domain.Wrappers;

namespace HotelServiceSystem.Application.RoomOrder.Commands.CreateRoomOrder;

public class CreateRoomOrderCommandHandler(IRoomServiceOrderRepository roomServiceOrderRepository,
    IGuestRepository guestRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateRoomOrderCommand, Result>
{

    public async Task<Result> Handle(CreateRoomOrderCommand request, CancellationToken cancellationToken)
    {
        var guest = await guestRepository.GetByIdAsync(request.RoomOrderModel.GuestId);
        var roomOrderItems = request.RoomOrderModel.RoomOrderItems.Select(roomOrder =>
        {
            var amount = OrderItemAmount.Create(roomOrder.Amount);
            if (amount.IsFailure)
            {
                Result.Failure<RoomOrderCreateDatabaseModel>(amount.Error);
            }
            return Result.Success(new RoomOrderCreateDatabaseModel
            {
                RoomServiceId = roomOrder.RoomServiceId,
                Amount = amount.Value
            });
        });
        var CreationSucessfull = Result.FirstFailureOrSuccess(roomOrderItems.ToArray());
        if (CreationSucessfull.IsFailure)
        {
            return CreationSucessfull;
        }
        var result = await roomServiceOrderRepository.CreateOrder(guest, roomOrderItems.Select(roi => roi.Value));
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
