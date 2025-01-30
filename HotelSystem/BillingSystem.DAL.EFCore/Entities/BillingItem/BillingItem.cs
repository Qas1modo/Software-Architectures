using BillingSystem.Domain.Entities.BillingItem.ValueObjects;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem;

public class BillingItem : AggregateRoot<CustomerId>
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
    public const string QuantityAmountCanNotBeZeroOrNegative = nameof(QuantityAmountCanNotBeZeroOrNegative);
    public const string UnitPriceCanNotBeZeroOrNegative = nameof(UnitPriceCanNotBeZeroOrNegative);
}
