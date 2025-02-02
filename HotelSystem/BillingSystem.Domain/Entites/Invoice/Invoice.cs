using BillingSystem.Domain.Core;
using BillingSystem.Domain.Entities.Invoice.ValueObjects;

namespace BillingSystem.Domain.Entities.Invoice;

public class Invoice : BillingSystemAggregateRoot
{
    public FinalPrice FinalPrice { get; set; }

    public CurrencyCode CurrencyCode { get; set; }

    public PaymentId PaymentId { get; set; }

    public IsPaid IsPaid { get; set; }
}
