using BillingSystem.DAL.EFCore.Primitives;

namespace BillingSystem.DAL.EFCore.DomainErrors
{
    public static class DomainErrors
    {
        public static class General
        {
            public static Error ServerError => new("General.ServerError", "Server fucked up");
        }

        public static class BillingItemErrors
        {
            public static Error ProductIdRequired => new("BillingItemErrors.ProductIdRequired", "Product id is requred for billing item");
            public static Error PriceRequired => new("BillingItemErrors.PriceRequired", "Price is required for billing item");
            public static Error QuantityRequired => new("BillingItemErrors.QuantityRequired", "Quantity is requaried for billing item");
            public static Error CustomerIdRequired => new("BillingItemErrors.CustomerIdRequired", "Customer is requaried for billing item");
        }
    }
}
