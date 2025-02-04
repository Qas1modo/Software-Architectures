namespace SharedKernel.Messages
{
    public record InvoicePaidMessage(Guid GuestId, Guid InvoiceId, string PaymentId);
}
