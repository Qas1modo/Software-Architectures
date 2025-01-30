namespace AccessSystem.Api.Contracts
{
    public static class ApiRoutes
    {
        public static class AccessCard
        {
            public const string Get = "accessCard";

            public const string Post = "accessCard";

            public const string Update = "accessCard";

            public const string Delete = "accessCard";

            public const string ResetCard = "accessCard/resetCard";
        }

        public static class Role
        {
            public const string Get = "role";

            public const string Post = "role";

            public const string Update = "role";

            public const string Delete = "role";
        }

        public static class AccessLog
        {
            public const string Get = "accessLog";
        }

        public static class AccessClaim
        {
            public const string Get = "accessClaim";

            public const string Post = "accessClaim";

            public const string Update = "accessClaim";

            public const string Delete = "accessClaim";

            public const string UpdateRoles = "accessClaim/updateRoles";
        }

        public static class Access
        {
            public const string RequestAccess = "access/requestAccess";
        }
    }
}
