using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessClaimPermission : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    
    public AccessClaimPermission(Guid accessClaimId, Guid permissionId) : base(Guid.NewGuid())
    {
        AccessClaimId = accessClaimId;
        PermissionId = permissionId;
    }

    public AccessClaimPermission()
    {
    }
    
    public Guid AccessClaimId { get; set; }
    public Guid PermissionId { get; set; }

    [ForeignKey(nameof(AccessClaimId))]
    public virtual AccessClaimEntity? AccessClaim { get; set; }

    [ForeignKey(nameof(PermissionId))]
    public virtual PermissionEntity? Permission { get; set; }
    
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }
}