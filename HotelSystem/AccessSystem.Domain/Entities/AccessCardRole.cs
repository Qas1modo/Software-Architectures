using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessCardRole : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public AccessCardRole(Guid accessCardId, Guid roleId) : base(Guid.NewGuid())
    {
        AccessCardId = accessCardId;
        RoleId = roleId;
    }

    public AccessCardRole()
    {
    }

    public Guid AccessCardId { get; set; }

    [ForeignKey(nameof(AccessCardId))]
    public virtual AccessCardEntity? AccessCard { get; set; }

    public Guid RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual RoleEntity? Role { get; set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool Deleted { get; }
}