using AccessSystem.Domain.Events.AccessCard;
using SharedKernel.Domain.Core.Events;
using SharedKernel.Messages;
using Wolverine;

namespace AccessSystem.Application.AccessCard.Events;

public class PremiumOrderAcceptedPivotalEventHandler(IMessageBus bus) : IDomainEventHandler<AccessCardUpdatedFromOrderDomainEvent>
{
    public async Task Handle(AccessCardUpdatedFromOrderDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(new RoleAcceptedOnOrderMessage(notification.GuestId, notification.OrderId));
    }
}