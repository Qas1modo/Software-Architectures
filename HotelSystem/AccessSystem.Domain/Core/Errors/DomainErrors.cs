using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static class DomainErrors
    {
        public static class PermissionErrors
        {
            public static Error PermissionName => new("PermissionErrors.PermissionName",
                "Permission name is required for permission.");

            public static Error PermissionDescription => new("PermissionErrors.PermissionDescription",
                "Permission description is required for permission.");

            public static Error NotFound => new("PermissionErrors.NotFound", "No permission found");

        }

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
            public static Error NotFound => new("AccessCardErrors.NotFound", "No such access card found"); }

        public static class AccessClaimErrors
        {
            public static Error NotFound => new("AccessClaimErrors.NotFound", "No such access claim found");
            
            public static Error AccessForbidden => new("AccessClaimErrors.AccessForbidden", "Access is forbidden");
        }
    }
}
