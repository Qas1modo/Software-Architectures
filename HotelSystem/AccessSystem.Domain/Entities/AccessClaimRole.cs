using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessClaimRole : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    
    public AccessClaimRole(Guid accessClaimId, Guid roleId) : base(Guid.NewGuid())
    {
        AccessClaimId = accessClaimId;
        RoleId = roleId;
    }

    public AccessClaimRole()
    {
    }
    
    public Guid AccessClaimId { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey(nameof(AccessClaimId))]
    public virtual AccessClaimEntity? AccessClaim { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual RoleEntity? Role { get; set; }
    
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }
}