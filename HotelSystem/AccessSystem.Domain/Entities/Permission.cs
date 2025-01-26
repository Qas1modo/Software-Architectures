using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.ValueObjects;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Utility;

namespace AccessSystem.Domain.Entities;

public class Permission : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    // TODO change permissionCodeName to value object
    public Permission(string permissionCodeName, PermissionName permissionName, PermissionDescription permissionDescription) : base(Guid.NewGuid())
    {
        PermissionCodeName = permissionCodeName;
        Ensure.NotEmpty(permissionName, DomainErrors.PermissionErrors.PermissionName, nameof(permissionName));
        Ensure.NotEmpty(permissionDescription, DomainErrors.PermissionErrors.PermissionDescription, nameof(permissionDescription));
        PermissionName = permissionName;
        PermissionDescription = permissionDescription;
    }

    private Permission() { }

    public string PermissionCodeName { get; private set; }
    public PermissionName PermissionName { get; private set; }
    public PermissionDescription PermissionDescription { get; private set; }

    public virtual List<AccessCard> AccessCards { get; set; } = [];

    public virtual List<RoleEntity> Roles { get; set; } = [];

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool Deleted { get; }
}