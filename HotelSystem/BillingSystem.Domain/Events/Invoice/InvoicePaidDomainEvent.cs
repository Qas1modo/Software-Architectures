using BillingSystem.Domain.Entities.Invoice;
using SharedKernel.Domain.Core.Events;

namespace BillingSystem.Domain.Events.Invoice
{
    public class InvoicePaidDomainEvent : IDomainEvent
    {
        public InvoicePaidDomainEvent(InvoiceEntity invoice) => Invoice = invoice;

        public InvoiceEntity Invoice { get; }
    }
}
