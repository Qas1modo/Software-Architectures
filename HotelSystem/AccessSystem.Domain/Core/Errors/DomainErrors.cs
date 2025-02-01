using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static class DomainErrors
    {
        public static class General
        {
            public static Error ServerError => new("General.ServerError", "An unexpected server error occurred.");
            public static Error UnProcessableRequest => new("General.UnProcessableRequest", "The server could not process the request.");
        }

        public static class RoleErrors
        {
            public static Error NotFound => new("RoleErrors.NotFound", "No role found");
        }

        public static class AccessCardErrors
        {
            public static Error NotFound => new("AccessCardErrors.NotFound", "No such access card found");
            
            public static Error RoleAlreadyAssigned => new("AccessCardErrors.RoleAlreadyAssigned", "Role is already assigned to the access card");
        }

        public static class AccessClaimErrors
        {
            public static Error NotFound => new("AccessClaimErrors.NotFound", "No such access claim found");

            public static Error AccessForbidden => new("AccessClaimErrors.AccessForbidden", "Access is forbidden");
        }
    }
}
