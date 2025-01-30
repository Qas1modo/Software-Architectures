using BillingSystem.DAL.Infrastructure.PaymentGateway.Interfaces;
using System.Text.Json;

namespace BillingSystem.DAL.Infrastructure.PaymentGateway.Base
{
    public abstract class BasePaymentGateway : IPaymentGateway
    {
        public async Task<string> GetPaymentRedirectionAsync(decimal valueToPay, Guid itemId)
        {
            var client = new HttpClient() 
            { 
                BaseAddress = new Uri("my.bank.com"),
                Timeout = TimeSpan.FromSeconds(5),
            };

            var paymentInfo = new Dictionary<string, string>()
            {
                { "value", $"{valueToPay}" },
                { "systemOrderId", $"{itemId}" },
            };

            HttpContent content = new StringContent(JsonSerializer.Serialize(paymentInfo));

            var response = await client.PostAsync("/payment/v2", content);

            var result = await response.Content.ReadAsStringAsync();

            return result ?? "TestOrderId";
        }

        public Task<bool> IsItemPaidAsync(int paymentId)
        {
            return Task.FromResult(true);
        }

        public bool IsSignCorrect(string dataToCheck, string signHash)
        {
            return dataToCheck == signHash;
        }
    }
}
