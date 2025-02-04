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
            public static Error CustomerIdIsDefault => new("BillingItemErrors.CustomerIdIsDefault", "Customer should have some id");
            public static Error ItemIdIsDefault => new("BillingItemErrors.ItemIdIsDefault", "Item should have an id");
            public static Error NegativeUnitPrice => new("BillingItemErrors.NegativeUnitPrice", "Item should not have negative price");
            public static Error NegativeQuantity => new("BillingItemErrors.NegativeQuantity", "Quantity should be possitive");
            public static Error DefaultBillingItemId => new("BillingItemErrors.DefaultBillingItemId", "Some Id should be passed for searching");
        }

        public static class InvoiceErrors
        {
            public static Error NotFound => new("InvoiceErrors.NotFound", "No invoice found");
            public static Error CustomerIdIsDefault => new("InvoiceErrors.CustomerIdIsDefault", "Customer should have some id");
            public static Error NoItemWasFound => new("InvoiceErrors.NoItemWasFound", "Customer does not have any items to pay");
            public static Error DefaultInvoiceId => new("BillingItemErrors.DefaultInvoiceId", "Some Id should be passed for searching");
        }

        public static class PaymentErrors
        {
            public static Error NotFound => new("PaymentErrors.NotFound", "No invoice found for which can be payment done");
        }
    }
}
