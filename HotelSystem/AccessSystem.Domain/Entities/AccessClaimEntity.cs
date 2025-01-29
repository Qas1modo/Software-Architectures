using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessClaimEntity(string codeName) : AggregateRoot(Guid.NewGuid()), IAuditableEntity, ISoftDeletableEntity
{
    public string CodeName { get; set; } = codeName;

    public virtual List<PermissionEntity> AllowedPermissions { get; set; } = [];

    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }

    public static AccessClaimEntity Create(string codeName)
    {
        var accessClaim = new AccessClaimEntity(codeName);
        return accessClaim;
    }
}