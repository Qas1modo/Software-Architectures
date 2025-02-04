namespace BillingSystem.Shared.Models.BillingItem;

public class BillingItemListModel
{
    public Guid CustomerId { get; set; }

    public Guid ItemId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
}
