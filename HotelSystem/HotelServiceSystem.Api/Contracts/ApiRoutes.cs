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

            public const string CancelOrder = "premiumservice/order/cancel";

        }

    }
}
