using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Events.RoomOrder;
using SharedKernel.Messages;
using Wolverine;

namespace HotelServiceSystem.Application.RoomOrder.Events;
public class SendRoomServiceFulfilledDomainEventHandler(IMessageBus bus) : IDomainEventHandler<RoomServiceOrderFulfilledDomainEvent>
{
    public async Task Handle(RoomServiceOrderFulfilledDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(new RoomOrderFulfilledMessage(notification.RoomServiceOrder.Guest.GlobalGuestId,
            notification.RoomServiceOrder.Id, notification.RoomServiceOrder.OrderItems.Sum(ro => ro.UnitPrice * ro.Amount)));
    }
}
