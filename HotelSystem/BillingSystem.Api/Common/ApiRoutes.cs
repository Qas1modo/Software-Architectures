namespace BillingSystem.Api.Common;

public static class ApiRoutes
{
    public static class BillingItems
    {
        public const string GetBillingItems = "billingItem";
        public const string CreateBillingItem = "billingItem";
        public const string UpdateBillingItem = "billingItem";
        public const string DeleteBillingItem = "billingItem";
    }

    public static class Invoice
    {
        public const string GetInvoice = "invoice";
        public const string CreateInvoice = "invoice";
        public const string UpdateInvoice = "invoice";
        public const string DeleteInvoice = "invoice";
    }

    public static class Payment
    {
        public const string IsInvoicePaid = "payment/isPaid";
        public const string GetPaymentRedirectUrl = "payment/redirection";
    }
}
