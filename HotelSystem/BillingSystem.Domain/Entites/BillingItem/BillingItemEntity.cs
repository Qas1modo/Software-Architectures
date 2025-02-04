using BillingSystem.Domain.Core;
using BillingSystem.Domain.Entities.BillingItem.ValueObjects;
using BillingSystem.Shared.Models.BillingItem;
using System.Runtime.Serialization;

namespace BillingSystem.Domain.Entities.BillingItem;

public class BillingItemEntity : BillingSystemAggregateRoot
{
    [IgnoreDataMember]
    public static string TableName = "BillingItems";

    public CustomerId CustomerId { get; private set; }

    public ItemId ItemId { get; private set; }

    public UnitPrice UnitPrice { get; private set; }

    public Quantity Quantity { get; private set; }

    // For EF.Core
    public BillingItemEntity() { }

    public BillingItemEntity(Guid customerId, Guid itemId, decimal unitPrice, int quanatity)
    {
        CustomerId = CustomerId.Create(customerId);
        ItemId = ItemId.Create(itemId).Value;
        UnitPrice = UnitPrice.Create(unitPrice).Value;
        Quantity = Quantity.Create(quanatity).Value;
    }

    public void Update(BillinItemUpdateModel billinItemUpdateModel)
    {
        if (billinItemUpdateModel.CustomerId is Guid newCustomerId)
        {
            CustomerId = CustomerId.Create(newCustomerId);
        }

        if (billinItemUpdateModel.ItemId is Guid newItemId)
        {
            ItemId = ItemId.Create(newItemId).Value;
        }

        if (billinItemUpdateModel.UnitPrice is decimal newUnitPrice)
        {
            UnitPrice = UnitPrice.Create(newUnitPrice).Value;
        }

        if (billinItemUpdateModel.Quantity is int newQuantity)
        {
            Quantity = Quantity.Create(newQuantity).Value;
        }
    }
}

public static class BillingItemErrors
{
    public const string ItemIdCannotBeDefault = nameof(ItemIdCannotBeDefault);
    public const string CustomerIdCannotBeDefault = nameof(CustomerIdCannotBeDefault);
    public const string InvoiceIdCannotBeDefault = nameof(InvoiceIdCannotBeDefault);
    public const string QuantityAmountCanNotBeZeroOrNegative = nameof(QuantityAmountCanNotBeZeroOrNegative);
    public const string UnitPriceCanNotBeZeroOrNegative = nameof(UnitPriceCanNotBeZeroOrNegative);
}
