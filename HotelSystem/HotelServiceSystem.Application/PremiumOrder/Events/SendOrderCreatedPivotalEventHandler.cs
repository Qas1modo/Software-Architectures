using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Events.PremiumOrder;
using SharedKernel.Messages;
using Wolverine;

namespace HotelServiceSystem.Application.PremiumOrder.Events;

public class SendOrderCreatedPivotalEventHandler(IMessageBus bus) : IDomainEventHandler<PremiumOrderCreatedDomainEvent>
{
    public async Task Handle(PremiumOrderCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(new PremiumOrderCreatedMessage(notification.PremiumServiceOrder.Guest.GlobalGuestId,
            notification.PremiumServiceOrder.Id, notification.PremiumServiceOrder.PremiumService.RelevantRoleCodeName));
    }
}
