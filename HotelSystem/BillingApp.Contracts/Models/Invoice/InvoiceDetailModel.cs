namespace BillingSystem.Shared.Models.Invoice;

public class InvoiceDetailModel
{
    public Guid CustomerId { get; set; }

    public decimal FinalPrice { get; set; }

    public string CurrencyCode { get; set; }

    public string PaymentId { get; set; }

    public bool IsPaid { get; set; }
}
