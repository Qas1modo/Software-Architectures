using BillingSystem.Domain.Events.Invoice;
using SharedKernel.Domain.Core.Events;
using SharedKernel.Messages;
using Wolverine;

namespace BillingSystem.Application.Invoice.Events;

public class PremiumOrderDeniedPivotalEventHandler(IMessageBus bus) : IDomainEventHandler<InvoicePaidDomainEvent>
{
    public async Task Handle(InvoicePaidDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(
            new InvoicePaidMessage(notification.Invoice.Id, notification.Invoice.CustomerId.Value, notification.Invoice.PaymentId.Value));
    }
}
