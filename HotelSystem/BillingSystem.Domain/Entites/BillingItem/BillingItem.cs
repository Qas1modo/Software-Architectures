using BillingSystem.Domain.Core;
using BillingSystem.Domain.Entities.BillingItem.ValueObjects;

namespace BillingSystem.Domain.Entities.BillingItem;

public class BillingItem : BillingSystemAggregateRoot
{
    public CustomerId CustomerId { get; private set; }

    public ItemId ItemId { get; private set; }

    public UnitPrice UnitPrice { get; private set; }

    public Quantity Quantity { get; private set; }

    public InvoiceId InvoiceId { get; private set; }
}

public static class BillingItemErrors
{
    public const string ItemIdCannotBeDefault = nameof(ItemIdCannotBeDefault);
    public const string CustomerIdCannotBeDefault = nameof(CustomerIdCannotBeDefault);
    public const string InvoiceIdCannotBeDefault = nameof(InvoiceIdCannotBeDefault);
    public const string QuantityAmountCanNotBeZeroOrNegative = nameof(QuantityAmountCanNotBeZeroOrNegative);
    public const string UnitPriceCanNotBeZeroOrNegative = nameof(UnitPriceCanNotBeZeroOrNegative);
}
