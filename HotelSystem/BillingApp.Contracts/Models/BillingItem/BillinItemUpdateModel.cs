namespace BillingSystem.Shared.Models.BillingItem;

public class BillinItemUpdateModel
{
    public Guid BillingItemId { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? ItemId { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public Guid? InvoiceId { get; set; }
}
