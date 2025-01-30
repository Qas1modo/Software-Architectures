using BillingSystem.Domain.Entities.Invoice.ValueObjects;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.Invoice;

public class Invoice : AggregateRoot<InvoiceId>
{
    public InvoiceId InvoiceId { get; set; }

    public FinalPrice FinalPrice { get; set; }

    public CurrencyCode CurrencyCode { get; set; }

    public PaymentId PaymentId { get; set; }

    public IsPaid IsPaid { get; set; }
}
