namespace SharedKernel.Messages
{
    /// <summary>
    /// Is published when Invoice is chaged from paid = false to paid = true
    /// </summary>
    public record InvoicePaidMessage(Guid GuestId, Guid InvoiceId, string PaymentId);
}
