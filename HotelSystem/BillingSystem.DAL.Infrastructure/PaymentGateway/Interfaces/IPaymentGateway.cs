namespace BillingSystem.DAL.Infrastructure.PaymentGateway.Interfaces
{
    public interface IPaymentGateway
    {
        public Task<string> GetPaymentRedirectionAsync(decimal valueToPay, Guid itemId);

        public Task<bool> IsItemPaidAsync(int paymentId);

        public bool IsSignCorrect(string dataToCheck, string signHash);
    }
}
