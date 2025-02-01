using AccessSystem.Domain.Events.AccessCard;
using SharedKernel.Domain.Core.Events;
using SharedKernel.Messages;
using Wolverine;

namespace AccessSystem.Application.AccessCard.Events;

public class PremiumOrderDeniedPivotalEventHandler(IMessageBus bus) : IDomainEventHandler<AccessCardUpdateFailedFromOrderDomainEvent>
{
    public async Task Handle(AccessCardUpdateFailedFromOrderDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(
            new RoleDeniedOnOrderMessage(notification.GuestId, notification.OrderId, notification.Error.Message));
    }
}