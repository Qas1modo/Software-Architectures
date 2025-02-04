namespace BillingSystem.Shared.Models.Invoice;

public class InvoiceUpdateModel
{
    public Guid InvoiceId { get; set; }

    public decimal? FinalPrice { get; set; }

    public string? CurrencyCode { get; set; }

    public string? PaymentId { get; set; }

    public bool? IsPaid { get; set; }
}
