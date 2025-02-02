using SharedKernel.Domain.Core.Primitives;

namespace BillingSystem.Domain.Core.Errors
{
    public static class DomainErrors
    {
        public static class General
        {
            public static Error ServerError => new("General.ServerError", "An unexpected server error occurred.");
            public static Error UnProcessableRequest => new("General.UnProcessableRequest", "The server could not process the request.");
        }

        public static class BillingItemErrors
        {
            public static Error NotFound => new("BillingItemErrors.NotFound", "No billing of customer found");
        }

        public static class InvoiceErrors
        {
            public static Error NotFound => new("InvoiceErrors.NotFound", "No invoice found");
        }

        public static class PaymentErrors
        {
            public static Error NotFound => new("PaymentErrors.NotFound", "No invoice found for which can be payment done");
        }
    }
}
