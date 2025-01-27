namespace HotelServiceSystem.Api.Contracts
{
    /// <summary>
    /// Contains the API endpoint routes.
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// Contains the authentication routes.
        /// </summary>
        public static class Guest
        {
            public const string Post = "guest";

            public const string DeactivateGuest = "guest/deactivate";

            public const string Update = "guest";

            public const string Delete = "guest";
        }

        public static class RoomService
        {
            public const string Get = "roomservice";

            public const string Post = "roomservice";

            public const string Delete = "roomservice";

            public const string Update = "roomservice";
        }

        public static class RoomServiceOrder
        {
            public const string Post = "roomservice/order";

            public const string Update = "roomservice/order";

            public const string Cancel = "roomservice/order/cancel";

            public const string Accept = "roomservice/order/accept";

            public const string Decline = "roomservice/order/decline";

            public const string Fulfill = "roomservice/order/fulfill";

            public const string GetNew = "roomservice/order/new";

            public const string GetCanceled = "roomservice/order/cancel";

            public const string GetAccepted = "roomservice/order/accept";

            public const string GetDeclined = "roomservice/order/decline";

            public const string GetFulfilled = "roomservice/order/fulfill";
        }


        public static class PremiumService
        {
            public const string Get = "premiumservice";

            public const string Post = "premiumservice";

            public const string Delete = "roomservice";

            public const string Update = "roomservice";
        }

        public static class PremiumServiceOrder
        {
            public const string CreateOrder = "premiumservice/order";

            public const string GetOrders = "premiumservice/order";

            public const string CancelOrder = "premiumservice/order/cancel";
        }

    }
}
