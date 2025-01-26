using AccessSystem.Domain.ValueObjects;
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
            public static Error PermissionName => new("PermissionErrors.PermissionName", "Permission name is required for permission.");
            public static Error PermissionDescription => new("PermissionErrors.PermissionDescription", "Permission description is required for permission.");
        }
        public static class PermissionNameErrors
        {
            public static Error NullOrEmpty => new("PermissionNameErrors.NullOrEmpty", "Permission name cannot be null or empty.");
            public static Error LongerThanAllowed => new("PermissionNameErrors.LongerThanAllowed", $"Permission name cannot exceed {PermissionName.MaxLength} characters.");
        }
        
        public static class PermissionDescriptionErrors
        {
            public static Error NullOrEmpty => new("PermissionDescriptionErrors.NullOrEmpty", "Permission description cannot be null or empty.");
            public static Error LongerThanAllowed => new("PermissionDescriptionErrors.LongerThanAllowed", $"Permission description cannot exceed {PermissionDescription.MaxLength} characters.");
        }
        
        public static class RoleNameErrors
        {
            public static Error NullOrEmpty => new("RoleNameErrors.NullOrEmpty", "Role name cannot be null or empty.");
            public static Error LongerThanAllowed => new("RoleNameErrors.LongerThanAllowed", $"Role name cannot exceed {PermissionName.MaxLength} characters.");
        }
        
        public static class RoleDescriptionErrors
        {
            public static Error NullOrEmpty => new("RoleDescriptionErrors.NullOrEmpty", "Role description cannot be null or empty.");
            public static Error LongerThanAllowed => new("RoleDescriptionErrors.LongerThanAllowed", $"Role description cannot exceed {PermissionDescription.MaxLength} characters.");
        }
        
        public static class General
        {
            public static Error ServerError => new("General.ServerError", "An unexpected server error occurred.");
            public static Error UnProcessableRequest => new("General.UnProcessableRequest", "The server could not process the request.");
        }
    }
}
