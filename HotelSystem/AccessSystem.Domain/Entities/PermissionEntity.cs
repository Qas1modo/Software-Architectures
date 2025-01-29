using System.ComponentModel.DataAnnotations;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class PermissionEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    // TODO change permissionCodeName to value object
    public PermissionEntity(string permissionCodeName, string permissionName, string permissionDescription) : base(Guid.NewGuid())
    {
        PermissionCodeName = permissionCodeName;
        PermissionName = permissionName;
        PermissionDescription = permissionDescription;
    }

    private PermissionEntity() { }

    [Required]
    public string PermissionCodeName { get; private set; }
    [Required]
    public string PermissionName { get; private set; }
    [Required]
    public string PermissionDescription { get; private set; }

    public virtual List<AccessCardEntity> AccessCards { get; set; } = [];

    public virtual List<RoleEntity> Roles { get; set; } = [];
    
    public virtual List<AccessClaimEntity> AccessClaims { get; set; } = [];

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool Deleted { get; }
    
    public static PermissionEntity Create(string permissionCodeName, string name, string description)
    {
        var permissionEntity = new PermissionEntity(permissionCodeName, name, description);

        return permissionEntity;
    }

    public PermissionEntity Update(string? permissionCodeName, string? name, string? description)
    {
        PermissionCodeName = permissionCodeName ?? PermissionCodeName;
        PermissionName = name ?? PermissionName;
        PermissionDescription = description ?? PermissionDescription;

        return this;
    }
}