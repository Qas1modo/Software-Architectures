using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessCardPermission : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public AccessCardPermission(Guid accessCardId, Guid permissionId) : base(Guid.NewGuid())
    {
        AccessCardId = accessCardId;
        PermissionId = permissionId;
    }

    public AccessCardPermission()
    {
    }

    public Guid AccessCardId { get; set; }
    public Guid PermissionId { get; set; }

    [ForeignKey(nameof(AccessCardId))]
    public virtual AccessCardEntity? AccessCard { get; set; }

    [ForeignKey(nameof(PermissionId))]
    public virtual PermissionEntity? Permission { get; set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool Deleted { get; }
}